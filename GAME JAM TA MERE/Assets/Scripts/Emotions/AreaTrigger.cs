using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour {


    public EmotionType.Type emotion;

    public float rate = 34f;

    public bool isActive = true;

    private EmotionManager emotionManager;
    


    private void OnTriggerStay(Collider collider)
    {
        GameObject collidingObject = collider.gameObject;
        if(isActive && collidingObject.tag == "Player")
        {
            // if colling object is the player then it has an impact on its emotions
            emotionManager = collidingObject.GetComponent<EmotionManager>();
            if(emotionManager.currentEmotion != emotion)
            {
                float amount = rate * Time.deltaTime;
                emotionManager.AddEmotion(emotion, amount);
            }
        }
    }
}
