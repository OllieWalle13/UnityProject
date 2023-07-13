using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hardMode : MonoBehaviour
{
    private Toggle toggle;
    [SerializeField] HardModeSetting HardModeSetting;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggle);
        });
    }

    void ToggleValueChanged(Toggle change)
    {
        HardModeSetting.changeMode();
    }
}
