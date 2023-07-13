using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource respawn;
    [SerializeField] private AudioSource death;
    [SerializeField] private GameObject HardModeSetting;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        HardModeSetting = GameObject.Find("HardModeSetting");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy")) {
            Die();
        }
    }

    private void Die() {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        death.Play();
    }

    private void RestartLevel() {
        if (HardModeSetting.GetComponent<HardModeSetting>().IsHardModeOn())
        {
            Debug.Log("hardmode");
            SceneManager.LoadScene("LevelOne");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log(SceneManager.GetActiveScene().name);
        }
    } 
}
