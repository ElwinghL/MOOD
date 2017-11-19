using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderIdle : MonoBehaviour
{

    private SpiderAnimation _spiderAnimation;

    void Start()
    {
        _spiderAnimation = transform.parent.gameObject.GetComponentInChildren<SpiderAnimation>();
    }

    private void triggerIdle()
    {
        _spiderAnimation.TriggerIdleAnimation();
    }
}
