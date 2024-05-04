using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOverUI.activeInHierarchy) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } else {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void gameOver() {
        gameOverUI.SetActive(true);        
        Time.timeScale = 0f;
        player.gameObject.SetActive(false);
    }

    public void RestartGame() {
        gameOverUI.SetActive(false); 
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu() {
        gameOverUI.SetActive(false); 
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
