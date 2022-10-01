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
	bool isFirstShuffle = true;
	float firstCardPosition;

	[SerializeField] StartingCardData startingCardData;

	List<int> drawableCardsInOrder = new List<int>();
	List<GameObject> cardsInHand = new List<GameObject>();
	List<int> discardPile = new List<int>();
	int numOfCardsInHand { get { return cardsInHand.Count; } }

	Dictionary<int, GameObject> cardDictionary = new Dictionary<int, GameObject>();
	Dictionary<GameObject, int> cardIDsDictionary = new Dictionary<GameObject, int>();

	// TODO: Remove card from draw pile when drawn.
	// TODO: Shuffle when there are no more cards in the draw pile.
	// TODO: Add card to discard pile when played.
	// TODO: Display the amount of cards left in the draw and discard pile.

	public void PlayCard(GameObject cardPlayed)
    {
		cardsInHand.Remove(cardPlayed);
		discardPile.Add(cardIDsDictionary[cardPlayed]);
		SimplePool.Despawn(cardPlayed);
		PositionCardsInHand();
		EventsManager.Instance.OnCardPlayed?.Invoke();
    }

	public void DrawHand(int numOfCards)
    {
		Debug.Log("Drawing a new hand");

        for (int i = 0; i < numOfCards; i++)
        {
			SpawnCard(GetCardFromId(drawableCardsInOrder[i]));
			spawnedCard.GetComponent<CardDisplay>().ChangeSortingLayer((CardSortingLayer)i);
			cardsInHand.Add(spawnedCard);

			EventsManager.Instance.OnCardDrawn?.Invoke();
        }

		PositionCardsInHand();
    }

	public void ShuffleDiscardPile()
    {
		int rand;
		int numOfCards = discardPile.Count;

        for (int i = 0; i < numOfCards; i++)
        {
			rand = Random.Range(0, discardPile.Count);
			drawableCardsInOrder.Add(discardPile[rand]);
			discardPile.RemoveAt(rand);
        }

		if (isFirstShuffle)
			EventsManager.Instance.OnFirstShuffle?.Invoke();
		EventsManager.Instance.OnCardsShuffled?.Invoke();

		isFirstShuffle = false;
    }

	void PositionCardsInHand()
    {
		offsetBetweenCards = distanceBetweenCards;
		float firstCardPosition = -Mathf.Floor((float)numOfCardsInHand / 2) * distanceBetweenCards;
		if (numOfCardsInHand % 2 == 0)
			firstCardPosition += (distanceBetweenCards / 2);

        for (int i = 0; i < numOfCardsInHand; i++)
        {
			cardsInHand[i].transform.localPosition = new Vector3(firstCardPosition + (i * offsetBetweenCards), 0);
		}
	}

	void SpawnCard(GameObject cardToSpawn)
    {
		spawnedCard = SimplePool.Spawn(cardToSpawn, transform.position, Quaternion.identity);
		spawnedCard.transform.parent = handCardsParent;
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
			cardIDsDictionary[cardIds.Object] = cardIds.ID;
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
		DrawHand(6);
    }
}
