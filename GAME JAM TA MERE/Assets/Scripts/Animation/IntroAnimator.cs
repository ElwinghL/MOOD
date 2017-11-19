using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimator : MonoBehaviour {

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("end", false);
    }

    private void triggerEnd()
    {
        _animator.SetBool("end",true);
    }

}
