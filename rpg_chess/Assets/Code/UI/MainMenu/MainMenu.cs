using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject comingSoonImage;

    [SerializeField]
    private TextMeshProUGUI continueText;
    [SerializeField]
    private TextMeshProUGUI loadText;
    [SerializeField]
    private TextMeshProUGUI newGameText;
    [SerializeField]
    private TextMeshProUGUI mapConstructorText;
    [SerializeField]
    private TextMeshProUGUI quitText;

    [SerializeField]
    private LevelLoader loadPanel;

    private void Start()
    {
        SetTextUI();
    }

    public void SetTextUI()
    {
        continueText.text = TextManager.GetTextById(2);
        loadText.text = TextManager.GetTextById(3);
        newGameText.text = TextManager.GetTextById(4);
        mapConstructorText.text = TextManager.GetTextById(5);
        quitText.text = TextManager.GetTextById(6);
    }

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
        loadPanel.LoadLevel();
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
