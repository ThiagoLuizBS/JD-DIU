using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
	[SerializeField] TMP_Text highscoreText;

    void start() {
        UpdateHUD();
    }

    private void Awake()
    {
        UpdateHUD();
    }

	private void UpdateHUD()
    {
		highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();		
    }
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
