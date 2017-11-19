﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAnimation : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        Debug.Log("Start");
        _animator = GetComponentInChildren<Animator>();
        _animator.SetBool("isDying", false);
        _animator.SetBool("isDead", false);
    }

    public void triggerDeathAnimation()
    {
        _animator.SetBool("isDying", true);
    }

    private void triggerDeadAnimation()
    {
        _animator.SetBool("isDead", true);
        _animator.SetBool("isDying", false);
    }
}
