using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLife : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioSource deathSound;
    private Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, 10f);
            anim.SetTrigger("dead");
            deathSound.Play();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
