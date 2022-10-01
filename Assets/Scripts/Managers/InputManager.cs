using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public System.Action OnExampleButtonPressed;

    void CheckForInput()
    {
        if (Input.GetButtonDown("Fire1"))
            OnExampleButtonPressed?.Invoke();
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
