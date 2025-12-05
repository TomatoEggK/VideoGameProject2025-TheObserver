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

    private bool isGameActive = true;

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
        messageText.text = "Time's Out! Game is Over!";
        messageText.gameObject.SetActive(true);

        Invoke("RestartLevel", 3f);
    }

    public void LevelComplete()
    {
        isGameActive = false;
        messageText.text = "Success!";
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
        else
        {
            Debug.Log("Congratulations on clearing all levels! Back to the first level soon.!");
            SceneManager.LoadScene(0); 
        }
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
