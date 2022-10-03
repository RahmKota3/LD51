using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
	public static CardsManager Instance;

	[SerializeField] List<IntToGameObjectDictionary> CardsList;

	[SerializeField] Transform handCardsParent;
	[SerializeField] Vector2 distanceBetweenCards = new Vector2(0.5f, 0.1f);
	[SerializeField] float rotationBetweenCards = 5.0f;

	Vector2 offsetBetweenCards;
	GameObject spawnedCard;
	bool isFirstShuffle = true;
	float firstCardPosition;

	[SerializeField] StartingCardData startingCardData;

	List<int> drawableCardsInOrder = new List<int>();
	List<GameObject> cardsInHand = new List<GameObject>();
	List<int> discardPile = new List<int>();
	int numOfCardsInHand { get { return cardsInHand.Count; } }
	public int NumOfCardsInDiscardPile { get { return discardPile.Count; } }
	public int NumOfCardsInDrawPile { get { return drawableCardsInOrder.Count; } }
	public int FullHandCardCount{ get { return (int)playerStatsController.GetAttributeValue(AttributeType.MaxCardsInHand); } }

	Dictionary<int, GameObject> cardDictionary = new Dictionary<int, GameObject>();
	Dictionary<GameObject, int> cardIDsDictionary = new Dictionary<GameObject, int>();

	StatsController playerStatsController;

	// TODO: Shuffle when there are no more cards in the draw pile.

	public void PlayCard(GameObject cardPlayed)
    {
		cardPlayed.GetComponent<CardPlayActions>().PlayCard();

		CardDisplay cd = cardPlayed.GetComponent<CardDisplay>();

		cardsInHand.Remove(cardPlayed);
		discardPile.Add(cd.cardData.ID);
		cardPlayed.transform.position = new Vector3(999, 999);
		SimplePool.Despawn(cardPlayed);
		PositionCardsInHand();
		EventsManager.Instance.OnCardPlayed?.Invoke();
		EventsManager.Instance.OnCardTypePlayed?.Invoke(cd.cardData.Type);

		if (numOfCardsInHand == 0)
		{
			ShuffleDiscardPile();
			DrawCards(FullHandCardCount);
		}
    }

	public void DrawCards(int numOfCards)
    {
		CardDisplay cd;

        for (int i = 0; i < numOfCards; i++)
        {
			SpawnCard(GetCardFromId(drawableCardsInOrder[0]));
			cd = spawnedCard.GetComponent<CardDisplay>();
			cd.ChangeSortingLayer((CardSortingLayer)i);
			cd.cardData.ID = drawableCardsInOrder[0];
			cardsInHand.Add(spawnedCard);
			drawableCardsInOrder.RemoveAt(0);

			if (NumOfCardsInDrawPile == 0)
				ShuffleDiscardPile();

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
		Vector2 firstCardPosition = new Vector2(-Mathf.Floor((float)numOfCardsInHand / 2) * distanceBetweenCards.x,
			-Mathf.Floor((float)numOfCardsInHand / 2) * distanceBetweenCards.y);
		float firstCardRotation = Mathf.Floor((float)numOfCardsInHand / 2) * rotationBetweenCards;
		if (numOfCardsInHand % 2 == 0)
		{
			firstCardPosition += new Vector2((distanceBetweenCards.x / 2), (distanceBetweenCards.y / 2));
			firstCardRotation -= rotationBetweenCards / 2;
		}

        for (int i = 0; i < numOfCardsInHand; i++)
        {
			cardsInHand[i].transform.localPosition = new Vector3(firstCardPosition.x + (i * offsetBetweenCards.x),
				GetCardYOffset(firstCardPosition.y, i), -i);
			cardsInHand[i].transform.localRotation = Quaternion.Euler(0, 0, firstCardRotation - 
				(rotationBetweenCards * i));
			cardsInHand[i].GetComponent<CardDisplay>().DefaultZPosition = cardsInHand[i].transform.localPosition.z;
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

	float GetCardYOffset(float firstCardYPosition, int currentCardCount)
    {
		int floorOfHalfCardsInHand = Mathf.FloorToInt(numOfCardsInHand / 2);
		float offsetBonus = 0;
		if (numOfCardsInHand % 2 == 0)
			offsetBonus += distanceBetweenCards.y / 2;

		if (currentCardCount < floorOfHalfCardsInHand)
			return ((-currentCardCount + floorOfHalfCardsInHand) * -distanceBetweenCards.y) + offsetBonus;
		else if (currentCardCount > Mathf.CeilToInt(numOfCardsInHand / 2))
			return ((currentCardCount - floorOfHalfCardsInHand) * -distanceBetweenCards.y) - offsetBonus;
		else
			return -offsetBonus;
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
		playerStatsController = ReferenceManager.Instance.PlayerStatsController;
		ShuffleDiscardPile();
		DrawCards(FullHandCardCount);
    }
}
