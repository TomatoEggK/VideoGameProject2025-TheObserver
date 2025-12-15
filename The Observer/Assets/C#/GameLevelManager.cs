using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLevelManager : MonoBehaviour
{
    public float totalTime = 60f;

    public TMP_Text timerText;
    public TMP_Text messageText;

    public bool isGameActive = true;

    public GameObject restartButton;

    void Update()
    {
        if (isGameActive == false) return;

        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            totalTime = 0;
            GameOver();
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        timerText.text = Mathf.CeilToInt(totalTime).ToString();
    }
    public void GameOver()
    {
        isGameActive = false;
        messageText.text = "Time's Out!";
        messageText.gameObject.SetActive(true);

        if (restartButton != null)
        {
            restartButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
    public void OnRestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LevelComplete()
    {
        isGameActive = false;
        messageText.text = "Item Found!";
        messageText.gameObject.SetActive(true);

        Invoke("LoadNextLevel", 2f);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
