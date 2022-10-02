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

	[HideInInspector] public int AliveEnemiesInEncounter = 0;

	Encounter currentEncounter;

	public void HandleEnemyDeath()
    {
        AliveEnemiesInEncounter -= 1;

		if (AliveEnemiesInEncounter == 0)
			EventsManager.Instance.OnEncounterFinished?.Invoke();
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

		GetRandomEncounter();
		AliveEnemiesInEncounter = currentEncounter.EnemiesInEncounter.Count;
		SpawnEnemies();
	}
}
