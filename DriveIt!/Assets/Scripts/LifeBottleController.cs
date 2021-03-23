using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBottleController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
   {
    MainCarController controller = other.GetComponent<MainCarController>();

    if (controller != null)
        {
            if(controller.health  < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }
}
