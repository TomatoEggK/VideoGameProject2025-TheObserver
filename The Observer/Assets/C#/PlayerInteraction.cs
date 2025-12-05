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
