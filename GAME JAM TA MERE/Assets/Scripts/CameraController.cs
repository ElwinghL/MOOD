using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{

	public float dampTime = 0.5f;
	public Transform target;
    public GameObject cameraGameObject;

    private Vector3 delta; // fixed distance between charac and camera

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        delta = target.transform.position - cameraGameObject.transform.position;
        //Debug.Log(gameObject + ": delta init: " + delta);
    }

    // Update is called once per frame
    void LateUpdate () 
	{
		if (target)
		{
			

            Vector3 destination = target.transform.position - delta;
            //Debug.Log(gameObject + ": destination: " + destination);

            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
		
	}

}
