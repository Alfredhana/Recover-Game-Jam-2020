using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public Text demageText;
    public void SetText(string text)
    {
        demageText.text = text;
    }
}
