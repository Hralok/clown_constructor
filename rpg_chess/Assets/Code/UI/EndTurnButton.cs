using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{

    private void Start()
    {
        transform.GetComponentInChildren<TextMeshProUGUI>().text = TextManager.GetTextById(14);
    }

    public void DoEndTurn()
    {
        // Конец хода
    }
}
