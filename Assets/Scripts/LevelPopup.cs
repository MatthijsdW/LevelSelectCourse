using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelPopup : MonoBehaviour
{
    public TextMeshProUGUI popupText;

    public void SetText(string text)
    {
        popupText.text = text;
    }
}
