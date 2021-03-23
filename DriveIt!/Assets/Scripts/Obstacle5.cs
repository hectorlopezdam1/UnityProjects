using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle5 : MonoBehaviour
{

    public float speed = 0.06f;

    Rigidbody2D rb2D;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 position = rb2D.position;
        position.x = position.x - speed;
        rb2D.MovePosition(position);
        
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        MainCarController player = other.gameObject.GetComponent<MainCarController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
        MainCarController player = other.gameObject.GetComponent<MainCarController>();
        if(other.gameObject.GetComponent<MainCarController>()){
            player.ChangeHealth(-1);
        }
    }

}
