using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;

    public void OnPlayerDied()
    {
        StopGame();
        gameOverPanel.SetActive(true);
    }
    
    public void OnMissionCompleted()
    {
        StopGame();
        gameWinPanel.SetActive(true);
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
