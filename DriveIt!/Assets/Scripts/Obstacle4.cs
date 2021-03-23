using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle4 : MonoBehaviour
{

    public float speedX = 10.0f;
    public float speedY = 6.0f;
    public bool horizontal;
    public float changeTime = 2.0f;

    Rigidbody2D rb2D;
    float timer;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        
        
        Vector2 position = rb2D.position;

        if (horizontal)
        {
            position.x = position.x + Time.deltaTime * speedX;
            position.y = position.y + Time.deltaTime * speedY * direction;
            rb2D.MovePosition(position);
        }
        
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
