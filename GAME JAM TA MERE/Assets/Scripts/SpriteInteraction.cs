using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInteraction : MonoBehaviour {

    public GameObject spriteObject;

    public float amplitude = 0.5f;
    public float transitionTime = 0.3f;

    private Transform spriteTransform;
    private Vector3 initScale;
    //private Vector3 minScale;
    private Vector3 maxScale;

    private Vector3 currentVelocity1 = Vector3.zero;
    private Vector3 currentVelocity2 = Vector3.zero;

    private bool mouseON = false;




    private void Update()
    {
        if (!mouseON)
        {
            GoToNormalSize();
        }
    }

    // Use this for initialization
    void Start () {
        initScale = spriteObject.transform.localScale;
        //minScale = initScale * (1f - amplitude);
        maxScale = initScale * (1f + amplitude);
        //Debug.Log(gameObject + "scales: " + initScale  + " ; " + maxScale);

        spriteTransform = spriteObject.transform;

    }

    void OnMouseOver()
    {
        Debug.Log(gameObject + ": the mouse is on me !");
        mouseON = true;
        GoToBiggerSize();
        //Invoke("MakeBlob", 2 * transitionTime);
    }

    private void OnMouseExit()
    {
        mouseON = false;
    }

    private void GoToBiggerSize()
    {
        spriteTransform.localScale = Vector3.SmoothDamp(spriteTransform.localScale, maxScale, ref currentVelocity1, transitionTime);
        //Invoke("GoToNormalSize", transitionTime + Mathf.Epsilon);
    }

    private void GoToNormalSize()
    {
        spriteTransform.localScale = Vector3.SmoothDamp(spriteTransform.localScale, initScale, ref currentVelocity2, transitionTime);

    }


}
