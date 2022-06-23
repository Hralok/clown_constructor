using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour 
{
    [SerializeField]
    private TextMeshProUGUI loadingText;

    public void Start()
    {
        loadingText.text = TextManager.GetTextById(12);
    }

    public void LoadLevel()
    {
        gameObject.SetActive(true);
        StartCoroutine(LoadAsynchronously(1));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        int i = 0;

        while (!operation.isDone)
        {
            i++;
            loadingText.text = TextManager.GetTextById(12) + new String('.', i);
            if (i >= 3) i = 0;

            yield return new WaitForSeconds(0.3f);
        }
    }
}
