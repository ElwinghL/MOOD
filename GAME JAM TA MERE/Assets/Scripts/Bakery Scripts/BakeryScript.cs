using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryScript : MonoBehaviour
{

    public SpriteRenderer thisSpriteRenderer;
    public Sprite FlowerAndNoCakeSprite;

    public Transform CakeSpawner;

    public bool hasCake = true;
    public bool hasFlowers = false;

    // true when the player is in the trigger, cakes is here but no flower
    // IT PISSES HIM OFF !
    public bool goCrazy = false;


    private CollectableManager collectableManager;
    private AreaTrigger thisAreaTrigger;

    // Use this for initialization
    void Start()
    {
        thisAreaTrigger = GetComponent<AreaTrigger>();
        collectableManager = GameObject.FindGameObjectWithTag("Player").GetComponent<CollectableManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject collidedObject = collider.gameObject;
        if (collidedObject.tag == "Player")
        {

            if (!hasFlowers)
            {
                if (hasCake)
                {
                    // TODO
                    if (collectableManager.heldCollectable == CollectableType.Type.FLOWER)
                    {
                        GiveFlowersForCake();
                    }
                    else
                    {
                        // start going crazy if player doesn't have flowers
                        goCrazy = true;

                    }
                }
            }

            //else
            //{
            //    if (!hasCake)
            //    {
            //        //Stop going crazy
            //        goCrazy = false;
            //        thisAreaTrigger.isActive = false;
            //    }
            //}
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        GameObject collidedObject = collider.gameObject;
        if (collidedObject.tag == "Player")
        {
            goCrazy = false;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        GameObject collidedObject = collider.gameObject;
        EmotionManager emotionManager = collidedObject.GetComponent<EmotionManager>();
        if (goCrazy && collidedObject.tag == "Player")
        {
            emotionManager.AddEmotion(EmotionType.Type.ANGER, 34);
        }
    }

    // used when the player gives the held flowers to get the cake
    private void GiveFlowersForCake()
    {
        collectableManager.heldCollectable = CollectableType.Type.NONE;

        goCrazy = false;
        thisAreaTrigger.isActive = false;


        // TODO : do we do something ?
        hasCake = false;
        hasFlowers = true;

        // hide the cake
        // display flowers
        thisSpriteRenderer.sprite = FlowerAndNoCakeSprite;
        CakeSpawner.gameObject.GetComponent<CakeSpawner>().DoYourShit();



    }



}
