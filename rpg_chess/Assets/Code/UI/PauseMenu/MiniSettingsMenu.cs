using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class MiniSettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    [SerializeField]
    private TextMeshProUGUI settingsText;
    [SerializeField]
    private TextMeshProUGUI volumeText;
    [SerializeField]
    private TextMeshProUGUI qualityText;

    private void Start()
    {
        SetTextUI();
    }

    public void SetTextUI()
    {
        settingsText.text = TextManager.GetTextById(1);
        volumeText.text = TextManager.GetTextById(8);
        qualityText.text = TextManager.GetTextById(9);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(5 - qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
