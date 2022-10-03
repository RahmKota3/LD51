using System.Collections;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
	public static TurnManager Instance;

	public bool IsPlayersTurn { get; private set; } = true;

	int enemyAttacks = 0;

	public void EnemyAttacked()
    {
		enemyAttacks += 1;

		if (enemyAttacks == ReferenceManager.Instance.NumOfAliveEnemies)
		{
			StartCoroutine(EndTurnAfterAWhile(0.25f));
		}
    }

	public void EndPlayerTurn()
    {
		if (IsPlayersTurn == false)
			return;

		IsPlayersTurn = !IsPlayersTurn;
		EventsManager.Instance.OnEnemyTurnStart?.Invoke();
    }

	public void EndEnemyTurn()
    {
		if (IsPlayersTurn)
			return;

		IsPlayersTurn = !IsPlayersTurn;
		EventsManager.Instance.OnPlayerTurnStart?.Invoke();

		enemyAttacks = 0;
	}

	IEnumerator EndTurnAfterAWhile(float seconds)
    {
		yield return new WaitForSeconds(seconds);

		EndEnemyTurn();
    }
	
	void Awake()
	{
		Instance = this;
	}

    private void Start()
	{
		EventsManager.Instance.OnPlayerTurnStart?.Invoke();
	}
}
