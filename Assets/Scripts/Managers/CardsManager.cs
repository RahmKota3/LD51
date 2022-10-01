using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
	public static CardsManager Instance;

	[SerializeField] List<IntToGameObjectDictionary> CardsList;

	[SerializeField] Transform handCardsParent;
	[SerializeField] float distanceBetweenCards = 0.5f;

	float offsetBetweenCards;
	GameObject spawnedCard;
	bool isFirstShuffle;

	[SerializeField] StartingCardData startingCardData;

	List<int> drawableCardsInOrder = new List<int>();
	List<int> cardsInHand = new List<int>();
	List<int> discardPile = new List<int>();

	Dictionary<int, GameObject> cardDictionary = new Dictionary<int, GameObject>();

	public void PlayCard()
    {

		EventsManager.Instance.OnCardPlayed?.Invoke();
    }

	public void DrawHand(int numOfCards)
    {
		Debug.Log("Drawing a new hand");

		offsetBetweenCards = distanceBetweenCards;
		float firstCardPosition = -Mathf.Floor((float)numOfCards / 2) * distanceBetweenCards;
		if (numOfCards % 2 == 0)
			firstCardPosition += (distanceBetweenCards / 2);

        for (int i = 0; i < numOfCards; i++)
        {
			SpawnCard(GetCardFromId(drawableCardsInOrder[i]), firstCardPosition, i);
			EventsManager.Instance.OnCardDrawn?.Invoke();
        }
    }

	public void ShuffleDiscardPile()
    {
		int rand;

        for (int i = 0; i < discardPile.Count; i++)
        {
			rand = Random.Range(0, discardPile.Count);
			drawableCardsInOrder.Add(discardPile[rand]);
			discardPile.RemoveAt(rand);
        }

		if (isFirstShuffle)
			EventsManager.Instance.OnFirstShuffle?.Invoke();
		EventsManager.Instance.OnCardsShuffled?.Invoke();
    }

	void SpawnCard(GameObject cardPrefab, float firstCardPosition, int spawnedCardCount)
    {
		spawnedCard = SimplePool.Spawn(cardPrefab, transform.position, Quaternion.identity);
		spawnedCard.transform.parent = handCardsParent;
		spawnedCard.transform.localPosition = new Vector3(firstCardPosition + (spawnedCardCount * offsetBetweenCards), 0);
		spawnedCard.GetComponent<CardDisplay>().ChangeSortingLayer((CardSortingLayer)spawnedCardCount);
	}

	void AddStartingCards()
    {
        for (int i = 0; i < startingCardData.StartingCards.Count; i++)
        {
			discardPile.Add(startingCardData.StartingCards[i]);
        }
    }

	void PopulateCardDictionary()
    {
        foreach (IntToGameObjectDictionary cardIds in CardsList)
        {
			cardDictionary[cardIds.ID] = cardIds.Object;
        }
    }

	GameObject GetCardFromId(int ID)
    {
		return cardDictionary[ID];
    }
	
	void Awake()
	{
		Instance = this;

		PopulateCardDictionary();
		AddStartingCards();
	}

    private void Start()
	{
		ShuffleDiscardPile();
		DrawHand(5);
    }
}
