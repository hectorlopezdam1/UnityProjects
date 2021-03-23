using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
    MainCarController player = other.GetComponent<MainCarController>();

        if (player != null)
        {
            player.ChangeHealth(-1);

        }

    }
}
