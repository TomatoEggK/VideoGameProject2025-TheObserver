using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // The maximum distance to interact.
    public float interactDistance = 3f;

    public GameLevelManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameLevelManager>();
    }
    void Update()
    {
        if (gameManager != null && gameManager.isGameActive == false)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        // Get the "MainCamera".
        Camera myCam = Camera.main;

        Ray ray = new Ray(myCam.transform.position, myCam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                MirrorEnding ending = hit.collider.GetComponent<MirrorEnding>();
                if (ending != null)
                {
                    ending.TriggerEnding();
                    return;
                }

                CommonEnding door = hit.collider.GetComponent<CommonEnding>();
                if (door != null)
                {
                    door.TriggerNormalEnding();
                    return;
                }

                Debug.Log("Item Found!");
                Destroy(hit.collider.gameObject);

                if (gameManager != null)
                {
                    gameManager.LevelComplete();
                }
            }

        }

    }
}
