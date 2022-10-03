using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowGameOverScreen : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI currentHighscoreTextBox;
    [SerializeField] TextMeshProUGUI previousHighscoreTextBox;

    [SerializeField] string currentHighscoreText = "Waves defeated: {0}";
    [SerializeField] string highscoreText = "Highscore: {0}";
    [SerializeField] string newHighscoreText = "New highscore!";

    void ShowGameOverWindow()
    {
        gameOverScreen.SetActive(true);
        PopulateGameOverWindow();
    }

    void PopulateGameOverWindow()
    {
        int highscore = Globals.GetHighscore();
        int currentScore = EncounterManager.Instance.CurrentWave;
        currentHighscoreTextBox.text = string.Format(currentHighscoreText, currentScore);

        if(currentScore > highscore)
        {
            previousHighscoreTextBox.text = newHighscoreText;
            Globals.SaveNewHighscore(currentScore);
        }
        else
        {
            previousHighscoreTextBox.text = string.Format(highscoreText, highscore);
        }
    }

    private void Start()
    {
        EventsManager.Instance.OnPlayerDeath += ShowGameOverWindow;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnPlayerDeath -= ShowGameOverWindow;
    }
}
