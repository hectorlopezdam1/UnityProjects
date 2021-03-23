using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreTextPlaying;
    public Text scoreTextGameOver;
    public float scoreAmount;
    public float pointIncreasedPerSecond;

    float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        pointIncreasedPerSecond = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(MainCarController.currentHealth > 0){
            scoreTextPlaying.text =  "SCORE: " + (int)scoreAmount;
            scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
        }
        scoreTextGameOver.text =  "SCORE: " + (int)scoreAmount;
    }
}
