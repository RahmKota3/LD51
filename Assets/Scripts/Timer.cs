using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    [HideInInspector] public float TimeLeftInTurn = 10f;

    bool playersTurn = true;
    bool paused = false;

    string format;

    [SerializeField] Color normalColor = Color.white;
    [SerializeField] Color shortTimeColor = Color.white;

    public void ReduceTime(float amount)
    {
        TimeLeftInTurn -= amount;
    }

    public void PauseTimer()
    {
        paused = true;
    }

    public void ResumeTimer()
    {
        paused = false;
    }

    public void StopTimer()
    {
        playersTurn = false;
        HideTimer();
    }

    public void HideTimer()
    {
        timer.gameObject.SetActive(false);
    }

    public void ShowTimer()
    {
        timer.gameObject.SetActive(true);
    }

    public void IncreaseTime(float increaseBy)
    {
        TimeLeftInTurn += increaseBy;
    }

    void DecreaseTime()
    {
        TimeLeftInTurn -= Time.deltaTime;

        if(TimeLeftInTurn <= 0)
        {
            TurnManager.Instance.EndPlayerTurn();
        }
    }

    void DisplayTime()
    {
        if (TimeLeftInTurn > 2)
        {
            format = "0";
            timer.color = normalColor;
        }
        else
        {
            format = "0.0";
            timer.color = shortTimeColor;
        }

        timer.text = TimeLeftInTurn.ToString(format) + "s";
    }

    void ResetTimer()
    {
        TimeLeftInTurn = 10f;
        timer.gameObject.SetActive(true);
        playersTurn = true;
    }

    void HandleEnemyTurnStart()
    {
        timer.gameObject.SetActive(false);
        playersTurn = false;
    }

    private void Start()
    {
        EventsManager.Instance.OnPlayerTurnStart += ResetTimer;
        EventsManager.Instance.OnEnemyTurnStart += HandleEnemyTurnStart;
        EventsManager.Instance.OnPlayerDeath += StopTimer;
        ResetTimer();
    }

    private void Update()
    {
        if (playersTurn == false || paused)
            return;

        DecreaseTime();
        DisplayTime();
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnPlayerTurnStart -= ResetTimer;
        EventsManager.Instance.OnEnemyTurnStart -= HandleEnemyTurnStart;
        EventsManager.Instance.OnPlayerDeath -= StopTimer;
    }
}
