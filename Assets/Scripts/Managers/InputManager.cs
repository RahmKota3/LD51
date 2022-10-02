using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    bool inputBlocked = false;

    void CheckForInput()
    {
        if (inputBlocked)
            return;

        // DEBUG
        if (Input.GetKeyDown(KeyCode.F))
            EventsManager.Instance.DEBUG_OnDrawCardsButtonPressed?.Invoke();
    }

    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        CheckForInput();
    }
}
