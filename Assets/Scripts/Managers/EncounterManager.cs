using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
	public static EncounterManager Instance;

	[SerializeField] List<Encounter> easyEncounters;
	[SerializeField] List<Encounter> mediumEncounters;
	[SerializeField] List<Encounter> hardEncounters;

	[SerializeField] Transform enemiesParent;
	float offsetBetweenEnemies = 2f;

	[SerializeField] Timer timer;

	[HideInInspector] public int AliveEnemiesInEncounter = 0;

	[HideInInspector] public int CurrentWave = 0;

	Encounter currentEncounter;

	int encountersToGetItem = 3;

	[SerializeField] Encounter testEncounter;

	public void HandleEnemyDeath()
    {
        AliveEnemiesInEncounter -= 1;

		if (AliveEnemiesInEncounter == 0)
		{
			timer.PauseTimer();

			InputManager.Instance.BlockInput();
			timer.HideTimer();
			EventsManager.Instance.OnEncounterFinished?.Invoke();

			encountersToGetItem -= 1;

			if (encountersToGetItem == 0)
			{
				GameReferenceManager.Instance.RewardScreenController.OpenRewardScreen();
				encountersToGetItem = 2;
			}
			else
            {
				StartCoroutine(SpawnWaveAfterDelay(1.5f));
            }
		}
    }

	public void SpawnNewWave()
    {
		timer.ResumeTimer();

		GenerateAndSpawnNewWave();
		InputManager.Instance.UnblockInput();
		timer.ShowTimer();
	}

	void GenerateAndSpawnNewWave()
    {
		GetRandomEncounter();
		AliveEnemiesInEncounter = currentEncounter.EnemiesInEncounter.Count;
		SpawnEnemies();

		CurrentWave += 1;
	}

    void SpawnEnemies()
    {
		for (int i = 0; i < AliveEnemiesInEncounter; i++)
        {
			Instantiate(currentEncounter.EnemiesInEncounter[i], GetSpawnPosition(i), Quaternion.identity, enemiesParent);
        }
    }

	void GetRandomEncounter()
    {
		if (testEncounter != null)
		{
			currentEncounter = testEncounter;
			return;
		}

		if (CurrentWave >= 6)
			IncreaseDifficulty();

        switch (ReferenceManager.Instance.CurrentEncounterDifficulty)
        {
			case EncounterDifficulty.Easy:
				currentEncounter = easyEncounters[Random.Range(0, easyEncounters.Count)];
				break;

			case EncounterDifficulty.Medium:
				currentEncounter = mediumEncounters[Random.Range(0, mediumEncounters.Count)];
				break;

			case EncounterDifficulty.Hard:
				currentEncounter = hardEncounters[Random.Range(0, hardEncounters.Count)];
				break;
		}
    }

	void IncreaseDifficulty()
    {
		if(ReferenceManager.Instance.CurrentEncounterDifficulty == EncounterDifficulty.Easy)
			ReferenceManager.Instance.CurrentEncounterDifficulty += 1;
    }

	IEnumerator SpawnWaveAfterDelay(float delay)
    {
		yield return new WaitForSeconds(delay);

		SpawnNewWave();
    }
	
	Vector3 GetSpawnPosition(int currentEnemy)
    {
		float firstSpawnPos = -Mathf.Floor(AliveEnemiesInEncounter / 2) * offsetBetweenEnemies;
		if (AliveEnemiesInEncounter % 2 == 0)
			firstSpawnPos += (offsetBetweenEnemies / 2);

		return new Vector3(firstSpawnPos + (currentEnemy * offsetBetweenEnemies), enemiesParent.position.y, 0);
    }

	void Awake()
	{
		Instance = this;

		GenerateAndSpawnNewWave();
	}
}
