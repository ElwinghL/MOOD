using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _playerBody;
    private UnityEngine.AI.NavMeshAgent _navMesh;
    private Vector3 _velocity;
    private float _idleThreshold = 0.01f;

    private InteractableObject waitingInteractable = null;


    // Use this for initialization
    void Start()
    {
        _playerBody = GetComponent<Rigidbody>();
        _navMesh = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitNavMesh;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitNavMesh))
            {
                Vector3 temp = hitNavMesh.point;
                _navMesh.destination = new Vector3(temp.x, 0.2f, temp.z);

                GameObject collidedObject = hitNavMesh.transform.gameObject;
                CheckInteraction(collidedObject);


            }
        }
        PlayAnimation();
    }

    public void Move(Vector3 playerVelocity)
    {
        _velocity = playerVelocity;
    }

    public void FixedUpdate()
    {
        _playerBody.MovePosition(_playerBody.position + _velocity * Time.fixedDeltaTime);
        //Debug.Log("Current Pos: " + _playerBody.transform.position);
    }


    // after moving, check any interaction with nearby interactableObject
    private void CheckInteraction(GameObject collidedObject)
    {
        // previous waitingInteractable is not waiting anymore
        if (waitingInteractable != null)
        {
            waitingInteractable.waitForInteraction = false;
        }
        if (collidedObject.tag == "Interactable")
        {
            // if we hit an interactable
            waitingInteractable = collidedObject.GetComponent<InteractableObject>();
            waitingInteractable.waitForInteraction = true;
            Debug.Log(gameObject + ": hit an interactable");
        }
        else
        {
            waitingInteractable = null;
        }
    }
    


    // play the walking/ idle animation
    private void PlayAnimation()
    {
        float velX = _navMesh.velocity.x * 10;
        float velZ = _navMesh.velocity.z * 10;
        _animator.SetFloat("VelX", velX);
        _animator.SetFloat("VelZ", velZ);
        if (_navMesh.remainingDistance > _idleThreshold)
        {
            _animator.SetBool("isMoving", true);
        }
        else if (_navMesh.remainingDistance <= _idleThreshold)
        {
            _animator.SetBool("isMoving", false);
        }
    }
}
