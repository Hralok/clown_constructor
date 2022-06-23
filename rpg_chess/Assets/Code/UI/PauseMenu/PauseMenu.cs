using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ShowPauseMenu()
    {
        gameObject.SetActive(true);
        // остановить игровое время
    }

    public void HidePauseMenu()
    {
        gameObject.SetActive(false);
        // возобновить игровое время
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        // Сохранить игру
        Application.Quit();
    }
}
