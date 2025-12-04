using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public float totalTime = 60f;
    public TMP_Text timerText;
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
            isGameActive = false;
            Debug.Log("Time's Out! Game is Over!");
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        timerText.text = Mathf.CeilToInt(totalTime).ToString();
    }
}
