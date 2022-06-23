using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    MainMenu mainMenu;

    [SerializeField]
    private TextMeshProUGUI settingsText;
    [SerializeField]
    private TextMeshProUGUI volumeText;
    [SerializeField]
    private TextMeshProUGUI qualityText;
    [SerializeField]
    private TextMeshProUGUI resolutionText;
    [SerializeField]
    private TextMeshProUGUI languageText;

    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        options.Reverse();

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = resolutions.Length - 1 - currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        SetTextUI();
    }

    public void SetTextUI()
    {
        settingsText.text = TextManager.GetTextById(1);
        volumeText.text = TextManager.GetTextById(8);
        qualityText.text = TextManager.GetTextById(9);
        resolutionText.text = TextManager.GetTextById(10);
        languageText.text = TextManager.GetTextById(11);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutions.Length - 1 - resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(5 - qualityIndex);
    }

    public void SwitchLanguage(string language)
    {
        if (language == "Russian")
        {
            TextManager.SetCurrentLanguage(LanguageEnum.Russian);
        }
        else if (language == "English")
        {
            TextManager.SetCurrentLanguage(LanguageEnum.English);
        }

        SetTextUI();
        mainMenu.SetTextUI();
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
