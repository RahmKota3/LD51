using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButtons : MonoBehaviour
{
    public void StartGame()
    {
        LevelManager.Instance.LoadLevel(LevelType.GameplayScene);
    }

    public void GoToMainMenu()
    {
        LevelManager.Instance.LoadLevel(LevelType.MainMenu);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
