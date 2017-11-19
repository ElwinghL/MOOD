using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.PostProcessing;

public class EmotionManager : MonoBehaviour
{
    private PostProcessingBehaviour postProcessing;

    private EmotionCueAnimation emotionCueManager;

    public ChangeWorld worldManager;

    public AudioManager audioManager;

    public EmotionType.Type currentEmotion = EmotionType.Type.JOY;

    public PostProcessingProfile JoyProcessingProfile;
    public PostProcessingProfile AngerProcessingProfile;
    public PostProcessingProfile FearProcessingProfile;

    public float joyCount = 0;
    public float angerCount = 0;
    public float fearCount = 0;

    void Start()
    {
        postProcessing = Camera.main.GetComponent<PostProcessingBehaviour>();
        emotionCueManager = GetComponentInChildren<EmotionCueAnimation>();
    }

    public void AddEmotion(EmotionType.Type emotion, float strength)
    {
        switch (emotion)
        {
            case EmotionType.Type.JOY:
                joyCount += strength;
                emotionCueManager.TriggerJoyAnimation();
                break;
            case EmotionType.Type.FEAR:
                fearCount += strength;
                emotionCueManager.TriggerFrightAnimation();
                break;
            case EmotionType.Type.ANGER:
                angerCount += strength;
                emotionCueManager.TriggerAngerAnimation();
                break;
        }
    }

    private void Update()
    {
        if (joyCount >= 100)
        {
            currentEmotion = EmotionType.Type.JOY;
            Debug.Log(gameObject + ": emotion set to "+currentEmotion);
            postProcessing.profile = JoyProcessingProfile;
            worldManager.ChangeWorldToJOY();
            audioManager.Stop();
            audioManager.Play("Joy");
            

            ResetCounters();
            return;
        }
        if (fearCount >= 100)
        {
            currentEmotion = EmotionType.Type.FEAR;
            Debug.Log(gameObject + ": emotion set to " + currentEmotion);
            postProcessing.profile = FearProcessingProfile;
            worldManager.ChangeWorldToFEAR();
            audioManager.Stop();
            audioManager.Play("Fear");

            ResetCounters();
            return;
        }
        if (angerCount >= 100)
        {
            currentEmotion = EmotionType.Type.ANGER;
            Debug.Log(gameObject + ": emotion set to " + currentEmotion);
            postProcessing.profile = AngerProcessingProfile;
            worldManager.ChangeWorldToANGER();
            audioManager.Stop();
            audioManager.Play("Anger");

            ResetCounters();
            return;
        }
    }

    // used when joyCount reaches 100
    private void BecomeHappy()
    {

    }

    private void ResetCounters()
    {
        joyCount = 0f;
        fearCount = 0f;
        angerCount = 0f;
    }
}
