using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
