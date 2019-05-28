using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

    public RectTransform playerPanel;
    public RectTransform inventoryPanel;
    public RectTransform pauseGamePanel;
    public GameObject player;
    private bool isPaused;
    PlayerController playerController;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        pauseGamePanel.gameObject.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        // If P is pressed
        if(Input.GetKeyDown(KeyCode.P))
        {
            // bool paused = !paused
            isPaused = !isPaused;

            if (isPaused)
            {
                // If paused - call paused function
                Pause();
            }

            if(!isPaused)
            {
                Resume();
            }

            // If !paused - call resume function
        }
    }

    public void Pause()
    {
        // Freeze Game
        Time.timeScale = 0;
        // Freeze Player
        playerController.FreezeMovement(isPaused);
        // Show Pause game UI
        pauseGamePanel.gameObject.SetActive(true);
    }

    public void Resume()
    {
        // Unfreeze game
        Time.timeScale = 1;
        // Unfreeze player
        playerController.FreezeMovement(isPaused);
        // Hide pause game UI
        pauseGamePanel.gameObject.SetActive(false);
    }

    // If resume button is pressed
    public void ResumeButtonPressed()
    {
        // paused = !paused
        isPaused = !isPaused;
        // Call resume method
        Resume();
    }
    

}
