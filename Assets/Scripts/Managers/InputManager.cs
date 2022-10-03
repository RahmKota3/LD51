using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public bool InputBlocked { get; private set; } = false;

    public Vector2 MousePos { get; private set; }

    void CheckForInput()
    {
#if UNITY_EDITOR
        // DEBUG
        if (Input.GetKeyDown(KeyCode.F))
            EventsManager.Instance.OnDebugButtonPressed?.Invoke();
#endif

        if (InputBlocked)
            return;

        if (Input.GetMouseButtonUp(0))
            EventsManager.Instance.OnLeftMouseUp?.Invoke();
    }

    void UpdateMousePos()
    {
        if(ReferenceManager.Instance.CurrentCamera == null)
        {
            Debug.Log("no camera!");
            return;
        }    
        MousePos = ReferenceManager.Instance.CurrentCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    public void BlockInput()
    {
        InputBlocked = true;
    }

    public void UnblockInput()
    {
        InputBlocked = false;
    }

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventsManager.Instance.OnPlayerTurnStart += UnblockInput;
        EventsManager.Instance.OnEnemyTurnStart += BlockInput;

        EventsManager.Instance.OnAfterSceneLoad += UnblockInput;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnPlayerTurnStart -= UnblockInput;
        EventsManager.Instance.OnEnemyTurnStart -= BlockInput;

        EventsManager.Instance.OnAfterSceneLoad -= UnblockInput;
    }

    private void Update()
    {
        UpdateMousePos();
        CheckForInput();
    }
}
