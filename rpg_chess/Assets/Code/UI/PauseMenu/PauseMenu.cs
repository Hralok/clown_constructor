using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ShowPauseMenu()
    {
        gameObject.SetActive(true);
        // ���������� ������� �����
    }

    public void HidePauseMenu()
    {
        gameObject.SetActive(false);
        // ����������� ������� �����
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        // ��������� ����
        Application.Quit();
    }
}
