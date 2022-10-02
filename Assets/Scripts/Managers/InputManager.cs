using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    bool inputBlocked = false;

    public Vector2 MousePos { get; private set; }

    void CheckForInput()
    {
        if (inputBlocked)
            return;

        if (Input.GetMouseButtonUp(0))
            EventsManager.Instance.OnLeftMouseUp?.Invoke();

        // DEBUG
        if (Input.GetKeyDown(KeyCode.F))
            EventsManager.Instance.DEBUG_OnDrawCardsButtonPressed?.Invoke();
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

    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        UpdateMousePos();
        CheckForInput();
    }
}
