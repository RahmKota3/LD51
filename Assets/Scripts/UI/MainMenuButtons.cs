using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        LevelManager.Instance.LoadLevel(LevelType.GameplayScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
