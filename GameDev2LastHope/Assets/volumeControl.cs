using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeControl : MonoBehaviour
{
    [SerializeField] private GameObject backgroundMusic;
    [SerializeField] private Slider volumeSlider;

    void OnEnable()
    {
        //Register Slider Events
        volumeSlider.onValueChanged.AddListener(delegate { changeVolume(volumeSlider.value); });
    }

    //Called when Slider is moved
    void changeVolume(float sliderValue)
    {
        backgroundMusic.GetComponent<AudioSource>().volume = sliderValue;
    }
}
