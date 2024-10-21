using System;
using UnityEngine;
using TMPro;

public class ChallengeTimer : MonoBehaviour
{
    public static Action OnWin = delegate { };
    public static Action OnLose = delegate { };

    public GameObject particlesPrefab;
    public GameObject ball;
    public float totalTime = 60f; // Duração do timer em segundos.
    private float currentTime;
    private bool isTimerRunning = false;

    public TextMeshProUGUI timerText; // Referência ao TextMeshProUGUI.
    public GameObject win;
    public GameObject lose;

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerDisplay();

        OnWin += StopTimer;
        OnLose += StopTimer;
        OnWin += ShowWin;
        OnLose += ShowLose;
    }

    void ShowWin()
    {
        if (!lose.activeSelf)
        {
            win.SetActive(true);
            
            if (ball)
            {
                Instantiate(particlesPrefab, ball.transform.position, Quaternion.identity);
                Destroy(ball);
            }
        }
    }

    void ShowLose()
    {
        if(!win.activeSelf)
            lose.SetActive(true);
    }

    private void OnDestroy()
    {
        OnWin -= StopTimer;
        OnLose -= StopTimer;
        OnWin -= ShowWin;
        OnLose -= ShowLose;
    }

    void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;

            // Atualiza a exibição do tempo.
            UpdateTimerDisplay();

            // Verifica se o tempo acabou.
            if (currentTime <= 0)
            {
                StopTimer();
                ActivateObject();
            }
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer() => isTimerRunning = false;
    
    private void UpdateTimerDisplay()
    {
        // Formata o tempo para mostrar no formato "MM:SS".
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void ActivateObject()
    {
        // Ativa o objeto ao fim do timer.
        if (win != null)
        {
            win.SetActive(true);
        }
    }
}