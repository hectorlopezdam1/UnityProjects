using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VikingCrew.Tools.UI.SpeechBubbleManager.Instance.AddSpeechBubble(transform, "Hello world!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
