using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;

    public static bool m_IsPlayerAtExit;
    float m_Timer;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    
    void Update ()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel ();
        }
    }

    void EndLevel ()
    {
        
        m_Timer += Time.deltaTime;

        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;
        if(DogeCoin.coins == 1){
            coin1.SetActive(true);
        }
        else if(DogeCoin.coins == 2){
            coin1.SetActive(true);
            coin2.SetActive(true);
        }
        else if(DogeCoin.coins == 3){
            coin1.SetActive(true);
            coin2.SetActive(true);
            coin3.SetActive(true);
        }

    }
}