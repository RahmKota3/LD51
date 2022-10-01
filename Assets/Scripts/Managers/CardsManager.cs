using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
	public static CardsManager Instance;

	[SerializeField] Transform handCardsParent;

	List<GameObject> Hand = new List<GameObject>();

	[SerializeField] float distanceBetweenCards = 0.5f;

	[SerializeField] GameObject _cardPlaceholder;

	float offsetBetweenCards;

	public void DrawHand()
    {
		int numOfCards = 5;
		offsetBetweenCards = distanceBetweenCards;
		float firstCardPosition = -Mathf.Floor((float)numOfCards / 2) * distanceBetweenCards;
		if (numOfCards % 2 == 0)
			firstCardPosition += (distanceBetweenCards / 2);

        for (int i = 0; i < numOfCards; i++)
        {
			GameObject g = SimplePool.Spawn(_cardPlaceholder, transform.position, Quaternion.identity);
			g.transform.parent = handCardsParent;
			g.transform.localPosition = new Vector3(firstCardPosition + (i * offsetBetweenCards), 0);
			g.GetComponent<CardDisplay>().ChangeSortingLayer((CardSortingLayer)i);
        }
    }
	
	void Awake()
	{
		Instance = this;
	}

    private void Start()
    {
		DrawHand();
    }
}
