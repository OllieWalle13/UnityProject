using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cheatCode : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene("LevelOne");
        }
        if (Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene("LevelTwo");
        }
        if (Input.GetKeyDown("3"))
        {
            SceneManager.LoadScene("LevelThree");
        }
    }
}
