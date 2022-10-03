using UnityEngine;

public class GameReferenceManager : MonoBehaviour
{
	public static GameReferenceManager Instance;

	public Transform ItemsUIElementsHolder;
	public Timer Timer;

	public GameObject ChooseItemMenu;

	public ChooseItemUI RewardScreenController;

	public int EnemyHpIncrease = 0;
	public int EnemyDamageIncrease = 0;
	
	void Awake()
	{
		Instance = this;
	}
}
