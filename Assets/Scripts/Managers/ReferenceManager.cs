﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    public static ReferenceManager Instance;

	public bool DontDestroy = true;

	public Camera CurrentCamera;

	public StatsController PlayerStatsController;

	public bool IsCardSelected = false;

	public float PlayCardYPosition = -1;

	void OnSceneLoaded()
    {
		FindACamera();
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
	
	void Awake()
	{
		Instance = this;

		if(LevelManager.Instance != null)
			EventsManager.Instance.OnAfterSceneLoad += OnSceneLoaded;

		if(CurrentCamera == null)
			FindACamera();
	}
}
