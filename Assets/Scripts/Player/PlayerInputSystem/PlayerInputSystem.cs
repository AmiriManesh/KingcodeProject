using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerInputSystem : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private PlayerInputAction playerInputAction;
    private float speed = 10f;

    private NavMeshAgent playerNavMesh;
    
    private void Awake()
    {
        GetComps();
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = playerInputAction.Player.WASD_Movement.ReadValue<Vector2>();
        playerRigidBody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }

    private void AssignMouseInputs()
    {
        playerInputAction.Player.PointCLick.performed += ctx => ClicktoMove();
    }

    private void ClicktoMove()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out  hit)
            && !hit.transform.CompareTag("Stick"))
            playerNavMesh.destination = hit.point;
    }

    private void GetComps()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerNavMesh = GetComponent<NavMeshAgent>();
        playerInputAction = new PlayerInputAction();
        AssignMouseInputs();
    }
    private void OnEnable()
    {
        playerInputAction.Player.Enable();
    }
    private void OnDisable()
    {
        playerInputAction.Player.Disable();
    }
}
