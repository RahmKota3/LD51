using System;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
	public static EventsManager Instance;

	public Action OnBeforeSceneLoad;
	public Action OnAfterSceneLoad;

	public Action OnCardDrawn;
	public Action OnCardPlayed;
	public Action OnCardsShuffled;
	public Action OnFirstShuffle;

	void Awake()
	{
		Instance = this;
	}
}
