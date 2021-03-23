using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCarController : MonoBehaviour
{
    public int maxHealth = 3;
    public int health { get { return currentHealth; }}
    public float timeInvincible = 0.01f;

    Rigidbody2D rb2d;
    public static int currentHealth;
    bool isInvincible;
    float invincibleTimer;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

     animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     
        float vertical = Input.GetAxis("Vertical");
        Vector2 position = rb2d.position;

        position.x = position.x + 0.3f;
        position.y = position.y + 30f * vertical * Time.deltaTime;

        rb2d.MovePosition(position);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            animator.SetTrigger("damaged");
            isInvincible = true;
            invincibleTimer = 0.7f;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
}
