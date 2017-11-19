using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectableItem   : InteractableObject {

    public CollectableType.Type collectableType;

    private CollectableManager collectableManager;

    public override void Start()
    {
        base.Start();
        collectableManager = GameObject.FindWithTag("Player").GetComponent<CollectableManager>();
    }

    public override void Interact()
    {
        Debug.Log(gameObject + ": I AM INTERACTING AND I AM A FCKING COLLECTABLE");
        collectableManager.heldCollectable = collectableType;
        
        gameObject.SetActive(false);
    }

}
