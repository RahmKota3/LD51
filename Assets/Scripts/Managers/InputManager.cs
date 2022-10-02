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

    void BlockInput()
    {
        InputBlocked = true;
    }

    void UnblockInput()
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
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnPlayerTurnStart -= UnblockInput;
        EventsManager.Instance.OnEnemyTurnStart -= BlockInput;
    }

    private void Update()
    {
        UpdateMousePos();
        CheckForInput();
    }
}
