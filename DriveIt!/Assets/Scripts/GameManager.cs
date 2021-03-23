using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelPause;
    public AudioSource tkDrift;

    void Start(){
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
        {
        PauseControl();
        }
        if(MainCarController.currentHealth == 0 || GameEnding.m_IsPlayerAtExit){
            if(Input.GetKeyDown(KeyCode.R)){
                GameEnding.m_IsPlayerAtExit = false;
                Restart();
                
            }
            if(Input.GetKeyDown(KeyCode.M)){
                GameEnding.m_IsPlayerAtExit = false;
                MainMenu();
            }
        }
    }
    
    public void PauseControl(){
        if(Time.timeScale == 1){
            panelPause.SetActive(true);
            Time.timeScale = 0;
            tkDrift.Pause();
        }else{
            Time.timeScale = 1;
            panelPause.SetActive(false);
            tkDrift.Play();
        }
    }

    public static void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu(){
        Application.LoadLevel(0);
    }

    public void StartGame(){
        Application.LoadLevel(1);
        if(Time.timeScale == 0){
            PauseControl();
        }
    }
}
