using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI menuText;
    [SerializeField]
    private TextMeshProUGUI continueText;
    [SerializeField]
    private TextMeshProUGUI settingsText;
    [SerializeField]
    private TextMeshProUGUI mainMenuText;
    [SerializeField]
    private TextMeshProUGUI quitText;

    private void Start()
    {
        SetTextUI();
    }

    public void SetTextUI()
    {
        menuText.text = TextManager.GetTextById(13);
        continueText.text = TextManager.GetTextById(2);
        settingsText.text = TextManager.GetTextById(1);
        mainMenuText.text = TextManager.GetTextById(0);
        quitText.text = TextManager.GetTextById(6);
    }

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
