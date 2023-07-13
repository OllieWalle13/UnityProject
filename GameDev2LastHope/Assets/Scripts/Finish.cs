using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    [SerializeField] private bool keyRequired = false;
    private ItemCollector ItemCollector;
    [SerializeField] private Text mainMessage;

    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (keyRequired)
            {
                ItemCollector = collision.GetComponent<ItemCollector>();
                if (ItemCollector.getKey())
                {
                    finishSound.Play();
                    CompleteLevel();
                }
                else
                {
                    mainMessage.text = "Key Required";
                }
            } else
            {
                finishSound.Play();
                CompleteLevel();
            }
        }
    }

    private void CompleteLevel()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
