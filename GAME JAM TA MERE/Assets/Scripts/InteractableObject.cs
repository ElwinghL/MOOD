using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    

    public bool isClickable = true; // nous clicable si mauvaise emotion ou si déjà tenu
    public bool waitForInteraction = false; // nous clicable si mauvaise emotion ou si déjà tenu

    public virtual void Start()
    {

    }

    // apply when object collides
    public void OnTriggerEnter(Collider collider)
    {
        GameObject collidedObject = collider.gameObject;

        if(collidedObject.tag == "Player")
        {
            // il ne se passe rien sauf si on a cliqué dessus
            if (waitForInteraction)
            {

                Interact();

            }
        }
        
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // MAKE IT GLOW BIAAATCH
        }
    }

    public virtual void Interact()
    {
        Debug.Log(gameObject + ": I AM INTERACTING");
    }



}
