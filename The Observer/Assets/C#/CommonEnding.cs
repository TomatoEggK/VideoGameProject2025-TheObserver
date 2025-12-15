using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class CommonEnding : MonoBehaviour
{
    public TMP_Text endingText;
    public GameObject Panel;

    public void TriggerNormalEnding()
    {
        GameLevelManager manager = FindObjectOfType<GameLevelManager>();
        if (manager != null)
        {
            manager.isGameActive = false;
            if (manager.timerText != null) manager.timerText.gameObject.SetActive(false);
        }

        StartCoroutine(EndingSequence());
    }

    IEnumerator EndingSequence()
    {
        if (Panel != null) Panel.SetActive(true);

        if (endingText != null)
        {
            endingText.text = "Simulation Complete.\nSubject Released.";
            endingText.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("CommonEndScene");
    }
}