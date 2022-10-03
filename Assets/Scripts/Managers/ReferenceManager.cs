using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    public static ReferenceManager Instance;

	public bool DontDestroy = true;

	public Camera CurrentCamera;

	public StatsController PlayerStatsController;

	public bool IsCardSelected = false;
	public Vector3 SelectedCardPos = Vector3.zero;
	public GameObject TargettingArrowObj;
	[HideInInspector] public GameObject SelectedEnemy = null;

	public float PlayCardYPosition = -1;

	public int NumOfAliveEnemies { get { return EncounterManager.Instance.AliveEnemiesInEncounter; } }

	public EncounterDifficulty CurrentEncounterDifficulty = EncounterDifficulty.Easy;

	void OnSceneLoaded()
    {
		FindACamera();
		GetTargettingArrow();
    }

	void GetTargettingArrow()
    {
		if (FindObjectOfType<TargettingArrow>() == null)
			return;

		TargettingArrowObj = FindObjectOfType<TargettingArrow>().gameObject;
		TargettingArrowObj.SetActive(false);
    }

	void FindACamera()
	{
		CurrentCamera = Camera.main;

		if(CurrentCamera == null)
        {
			CurrentCamera = FindObjectOfType<Camera>();

			if(CurrentCamera == null)
            {
				Debug.LogError("No camera found.");
            }
        }
    }

	void GenerateRandomSeed()
    {
		UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
    }
	
	void Awake()
	{
		Instance = this;

		if(LevelManager.Instance != null)
			EventsManager.Instance.OnAfterSceneLoad += OnSceneLoaded;

		if(CurrentCamera == null)
			FindACamera();

		GenerateRandomSeed();
	}
}
