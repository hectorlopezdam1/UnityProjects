using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MusicControllerGame : MonoBehaviour
{
    public AudioSource tkDrift;
    public AudioSource olebeti;
    public AudioSource gameOver;
    bool stop = false;
    public CanvasGroup gameOverImageCanvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        tkDrift.Play();
        stop = true;
    }
 
    // Update is called once per frame
    void Update()
    {
        if(stop){
            olebeti.Pause();
            gameOver.Pause();
        }
        if(GameEnding.m_IsPlayerAtExit){
            tkDrift.Stop();
            olebeti.Play();
        }
        if(MainCarController.currentHealth == 0){
            tkDrift.Stop();
            gameOver.Play();
        }
        if(gameOverImageCanvasGroup.alpha == 1){
            gameOver.Stop();
        }
        
        
    }
}
