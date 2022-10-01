using UnityEngine;

public class EventsManager : MonoBehaviour
{
	public static EventsManager Instance;

	public System.Action OnBeforeSceneLoad;
	public System.Action OnAfterSceneLoad;

	void Awake()
	{
		Instance = this;
	}
}
