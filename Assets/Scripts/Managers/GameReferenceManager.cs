using UnityEngine;

public class GameReferenceManager : MonoBehaviour
{
	public static GameReferenceManager Instance;

	public Transform ItemsUIElementsHolder;
	public Timer Timer;

	public GameObject ChooseItemMenu;

	public ChooseItemUI RewardScreenController;
	
	void Awake()
	{
		Instance = this;
	}
}
