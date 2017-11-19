using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyControl : MonoBehaviour {


    public float moveSpeed = 1f;




	// Use this for initialization
	void Start () {
        


    }

    // Update is called once per frame
    void Update () {

        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 displacement = new Vector3(horz, 0f, vert) * Time.deltaTime;


        this.transform.position += displacement;

	}



}
