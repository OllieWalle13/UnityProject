using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampoline : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private AudioSource trampolineEffect;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, jumpForce);
            anim.SetTrigger("Jumped");
            trampolineEffect.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anim.ResetTrigger("Jumped");
        }
    }
}
