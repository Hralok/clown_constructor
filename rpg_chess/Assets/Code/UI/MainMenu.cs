using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject comingSoonImage;

    IEnumerator SetOff()
    {
        Color startText = comingSoonImage.transform.GetComponentInChildren<TextMeshProUGUI>().color;
        Color startOther = comingSoonImage.transform.GetComponent<Image>().color;

        while (true)
        {
            TextMeshProUGUI forText = comingSoonImage.transform.GetComponentInChildren<TextMeshProUGUI>();
            Image forOther = comingSoonImage.transform.GetComponent<Image>();

            forText.color = Color.Lerp(forText.color, Color.clear, 1.0f * Time.deltaTime);
            forOther.color = Color.Lerp(forOther.color, Color.clear, 1.0f * Time.deltaTime);

            yield return null;

            if (forText.color.a < 0.1f && forOther.color.a < 0.1f)
            {
                comingSoonImage.SetActive(false);
                forText.color = startText;
                forOther.color = startOther;
                StopCoroutine("SetOff");
            }
        }
    }
    public void ComingSoon()
    {
        comingSoonImage.SetActive(true);

        StartCoroutine("SetOff");
    }

    public void ContinueGame()
    {
        // Загрузка последней игры
    }

    public void LoadGame()
    {
        // Список сохраненных игр
    }

    public void NewGame()
    {
        // Новая игра - выбор правил и тд.
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
