using System;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
	public static EventsManager Instance;

    #region LevelManager
    public Action OnBeforeSceneLoad;
	public Action OnAfterSceneLoad;
    #endregion

    #region CardActions
    public Action OnCardDrawn;
	public Action OnCardPlayed;
	public Action OnCardsShuffled;
	public Action OnFirstShuffle;
	#endregion

	#region Input
    public Action OnLeftMouseUp;
    public Action OnDebugButtonPressed;
	#endregion

	#region Turn management
	public Action OnEnemyTurnStart;
	public Action OnPlayerTurnStart;
	#endregion

	#region Encounter
	public Action OnEncounterFinished;
    #endregion

    void Awake()
	{
		Instance = this;
	}
}
