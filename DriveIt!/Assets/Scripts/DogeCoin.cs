using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogeCoin : MonoBehaviour
{
    public static int coins = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
    MainCarController controller = other.GetComponent<MainCarController>();

        if (controller != null)
        {
            Destroy(gameObject);
            coins++;
        }

    }
}
