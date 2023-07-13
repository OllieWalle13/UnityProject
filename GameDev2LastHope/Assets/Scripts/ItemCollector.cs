using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int strawberries = 0;
    private int kiwi = 0;
    private bool key;

    [SerializeField] private AudioSource itemPickUp;

    [SerializeField] private Text strawberriesText;
    [SerializeField] private Text kiwiText;
    [SerializeField] private Text keyText;

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.CompareTag("Strawberry")) {
            Destroy(collision.gameObject);
            itemPickUp.Play();
            strawberries += 1;

            strawberriesText.text = "Strawberries: " + strawberries;
        }

        if (collision.gameObject.CompareTag("Kiwi"))
        {
            Destroy(collision.gameObject);
            itemPickUp.Play();
            kiwi += 1;
            kiwiText.text = "Double Jump Kiwi Activated";
        }

        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            itemPickUp.Play();
            key = true;
            keyText.text = "You have a key!";
        }
    }

    public bool getKiwi ()
    {
        if (kiwi == 0)
        {
            return false;
        }
        return true;
    }

    public bool getKey () {
        return key;
    }


    public int getStrawberry ()
    {
        return strawberries;
    }

    public void removeStrawberry ()
    {
        strawberries -= 1;
        strawberriesText.text = "Strawberries: " + strawberries;
    }
}
