using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup gameOverImageCanvasGroup;
    float m_Timer;

    void Update()
    {
        if(MainCarController.currentHealth == 0)
        {
            Destroy(player);
            ShowGameOverScreen();
            
        }
    }

    void ShowGameOverScreen()
    {
        m_Timer += Time.deltaTime;
        gameOverImageCanvasGroup.alpha = m_Timer / fadeDuration;

    }
    
}
