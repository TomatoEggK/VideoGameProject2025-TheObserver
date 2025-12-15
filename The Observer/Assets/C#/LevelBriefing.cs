using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelBriefing : MonoBehaviour
{
    [Header("UI Components")]
    public TMP_Text briefingText;

    [Header("Settings")]
    public float displayDuration = 5f;

    void Start()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        ShowBriefing(sceneIndex);

        StartCoroutine(HideTextSequence());
    }

    void ShowBriefing(int levelIndex)
    {
        string message = "";

        switch (levelIndex)
        {
            case 1:
                message = "SYSTEM: Training Program Initialized.\nOBJECTIVE: Find the Key.";
                break;
            case 2:
                message = "SIMULATION: 001 [ROOM]\nTEST: Obedience.\nDIRECTIVE: Find the Key.";
                break;
            case 3:
                message = "SIMULATION: 002 [LIGHT]\nTEST: Visual Sensors.\nDIRECTIVE: Find the Key.";
                break;
            case 4: 
                message = "SIMULATION: 003 [LADDER]\nTEST: Fear Response.\nDIRECTIVE: Find the Key.";
                break;
            case 5:
                message = "WARNING: System Data Overflow...\nLogic Failure Detected...\nDIRECTIVE: [DATA EXPUNGED]";
                break;
            default:
                message = "";
                break;
        }

        if (briefingText != null && message != "")
        {
            briefingText.text = message;
            briefingText.gameObject.SetActive(true);
        }
    }

    IEnumerator HideTextSequence()
    {
        yield return new WaitForSeconds(displayDuration);

        if (briefingText != null)
        {
            briefingText.text = "";
            briefingText.gameObject.SetActive(false);
        }
    }
}