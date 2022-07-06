using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float timeForTick=4f;
    private int timeMinute = 0;
    private int timeHour = 0;

    [SerializeField] private Text timeText;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject anomaliesManager;

    private void Start()
    {
        UpdateTimeUI();
        AnomaliesManager.tooMuchAnomalies+=PlayerLost;
    }

    private void Update()
    {
        timeForTick -= Time.deltaTime;
        if(timeForTick<0)
        {
            ChangeTime();
            timeForTick = 4f;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }

    private void ChangeTime()
    {
        timeMinute++;
        if(timeMinute>59)
        {
            timeMinute = 0;
            timeHour++;
        }
        
        UpdateTimeUI();

        if(timeHour==6)
        {
            PlayerWon();
        }
    }

    private void UpdateTimeUI()
    {
        string timeStr;
        timeStr = "0" + timeHour.ToString()+":";
        if(timeMinute<10)
        {
            timeStr += "0" + timeMinute.ToString();
        }
        else
        {
            timeStr += timeMinute.ToString();
        }

        timeText.text = timeStr;
    }


    private void PlayerWon()
    {
        StartCoroutine(WinScreen());
    }

    private void PlayerLost()
    {
        
        StartCoroutine(LoseScreen());
        
    }

    private IEnumerator WinScreen()
    {
        anomaliesManager.SetActive(false);
        winScreen.SetActive(true);
        yield return new WaitForSeconds(10f);
        LoadMainMenu();
    }

    private IEnumerator LoseScreen()
    {
        anomaliesManager.SetActive(false);
        loseScreen.SetActive(true);
        yield return new WaitForSeconds(10f);
        LoadMainMenu();
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
