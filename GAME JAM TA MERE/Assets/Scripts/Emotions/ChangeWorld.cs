using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ChangeWorld : MonoBehaviour {

    public Camera mainCamera;

    public GameObject angerGround;
    public GameObject fearGround;
    public GameObject joyGround;

    public Sprite angerTree;
    public Sprite fearTree;
    public Sprite joyTree;

    public PostProcessingProfile angerCameraEffect;
    public PostProcessingProfile fearCameraEffect;
    public PostProcessingProfile joyCameraEffect;

    public void ChangeWorldToJOY()
    {
        // Changing the tiles
        angerGround.SetActive(false);
        fearGround.SetActive(false);
        joyGround.SetActive(true);

        // Changing Trees
        GameObject[] trees;
        trees = GameObject.FindGameObjectsWithTag("Tree");
        foreach (GameObject tree in trees)
        {
            tree.transform.Find("TreeSprite").GetComponent<SpriteRenderer>().sprite = joyTree;
        }

        mainCamera.GetComponent<PostProcessingBehaviour>().profile = joyCameraEffect;
    }

    public void ChangeWorldToFEAR()
    {
        // Changing the tiles
        angerGround.SetActive(false);
        fearGround.SetActive(true);
        joyGround.SetActive(false);

        // Changing Trees
        GameObject[] trees;
        trees = GameObject.FindGameObjectsWithTag("Tree");
        foreach (GameObject tree in trees)
        {
            tree.transform.Find("TreeSprite").GetComponent<SpriteRenderer>().sprite = fearTree;
        }

        mainCamera.GetComponent<PostProcessingBehaviour>().profile = fearCameraEffect;
    }

    public void ChangeWorldToANGER()
    {
        // Changing the tiles
        angerGround.SetActive(true);
        fearGround.SetActive(false);
        joyGround.SetActive(false);

        // Changing Trees
        GameObject[] trees;
        trees = GameObject.FindGameObjectsWithTag("Tree");
        foreach (GameObject tree in trees)
        {
            tree.transform.Find("TreeSprite").GetComponent<SpriteRenderer>().sprite = angerTree;
        }

        mainCamera.GetComponent<PostProcessingBehaviour>().profile = angerCameraEffect;
    }

}
