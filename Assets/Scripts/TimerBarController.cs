using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TimerBarController : MonoBehaviour
{
    public Slider slider;
    public bool timesup;
    public float maxTime;
    public GameObject customText;
    float timer;

    public void ResetTimer()
    {
        timer = 0;
        slider.value = timer;
        timesup = false;
        customText.gameObject.SetActive(false);
    }

    public void StartTimer()
    {
        if (!timesup)
        {
            if (slider.value < 1)
            {
                timer += Time.deltaTime;
                slider.value = timer / maxTime;
            }
            else
            {
                customText.gameObject.SetActive(true);
                timesup = true;
            }
        }
    }
}
