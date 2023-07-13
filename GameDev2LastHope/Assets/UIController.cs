using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject volumeWindow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (volumeWindow.activeSelf == true)
            {
                volumeWindow.SetActive(false);
            }
            else
            {
                volumeWindow.SetActive(true);
            }
        }
    }
}
