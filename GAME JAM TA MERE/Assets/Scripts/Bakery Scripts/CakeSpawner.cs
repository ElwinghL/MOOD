using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeSpawner : MonoBehaviour {

    public GameObject FlyingCakePrefab;

    public GameObject createdFlyingCake;

    public float force = 1f;

    // spawn a cake
    public void DoYourShit()
    {
        Debug.Log(gameObject + ": throwing a cake");
        createdFlyingCake = Instantiate(FlyingCakePrefab, this.transform.position,Quaternion.identity) as GameObject;
        createdFlyingCake.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 1f, -1f) * force);
        //Invoke("StopVelocity", 0.5f);

    }

    private void StopVelocity()
    {
        createdFlyingCake.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }


}
