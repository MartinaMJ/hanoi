using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sliderBehaviour : MonoBehaviour
{
    public Slider _slider;
    public gameController gcontroller;

    public TextMeshProUGUI sliderText;
    // Start is called before the first frame update
    void Start()
    {
        _slider.onValueChanged.AddListener((v) => UpdateNumber(v)
        );
    }

    private void UpdateNumber(float v)
    {
        sliderText.text = "N: " + v.ToString("0");
        gcontroller.size = (int)v;
        gcontroller.Clear();
        gcontroller.Setup();
    }
}
