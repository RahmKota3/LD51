using UnityEngine;

public class TurnManager : MonoBehaviour
{
	public static TurnManager Instance;

	bool isPlayersTurn = true;

	int enemyAttacks = 0;

	public void EnemyAttacked()
    {
		enemyAttacks += 1;

		if (enemyAttacks == ReferenceManager.Instance.NumOfEnemies)
			EndTurn();
    }

	public void EndTurn()
    {
		if(isPlayersTurn)
        {
			isPlayersTurn = false;
			EventsManager.Instance.OnEnemyTurnStart?.Invoke();
        }
        else
        {
			isPlayersTurn = true;
			EventsManager.Instance.OnPlayerTurnStart?.Invoke();
        }

		enemyAttacks = 0;
    }
	
	void Awake()
	{
		Instance = this;

		EventsManager.Instance.OnDebugButtonPressed += EndTurn;
	}
}
