using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Framerate : MonoBehaviour
{
    void Awake()
    {
        // Used to limit framerate in Editor to help prevent crashes on my Macbook Air
        #if UNITY_EDITOR
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 45;
        #endif
    }
}
