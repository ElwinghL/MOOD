using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionCueAnimation : MonoBehaviour {

    private Animator _animator;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _animator.SetBool("isHappy", false);
        _animator.SetBool("isAngry", false);
        _animator.SetBool("isScared", false);
    }

    public void TriggerAngerAnimation()
    {
        _animator.SetBool("isAngry", true);
    }

    public void TriggerJoyAnimation()
    {
        _animator.SetBool("isHappy", true);
    }

    public void TriggerFrightAnimation()
    {
        _animator.SetBool("isScared", true);
    }

    private void TriggerIdleAnimation()
    {
        _animator.SetBool("isHappy", false);
        _animator.SetBool("isAngry", false);
        _animator.SetBool("isScared", false);
    }
}
