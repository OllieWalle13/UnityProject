using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardModeSetting : MonoBehaviour
{
    private bool HardModeOn = false;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void changeMode ()
    {
        HardModeOn = !HardModeOn;
        Debug.Log("Hard Mode: " + HardModeOn);
    }

    public bool IsHardModeOn()
    {
        return HardModeOn;
    }

}
