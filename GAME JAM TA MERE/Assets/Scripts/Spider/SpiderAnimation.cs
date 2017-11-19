using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimation : MonoBehaviour {

    public Animator _animator;

    void Start()
    {
        Debug.Log("Start");
        //_animator = GetComponentInChildren<Animator>();
        _animator.SetBool("isSpitting", false);
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        if (_animator.GetBool("isSpitting"))
    //        {
    //            TriggerIdleAnimation();
    //        }
    //        else
    //        {
    //            TriggerSpitAnimation();
    //        }
    //    }
    //}

    public void OnTriggerEnter(Collider collider)
    {
        GameObject collidedObj = collider.gameObject;
        if(collidedObj.tag == "Player")
        {
                TriggerSpitAnimation();
        }
        
    }

    public void TriggerSpitAnimation()
    {
        _animator.SetBool("isSpitting", true);
    }

    public void TriggerIdleAnimation()
    {
        _animator.SetBool("isSpitting", false);
    }
}
