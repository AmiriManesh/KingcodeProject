using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private PlayerInputAction playerInputAction;
    private float speed = 10f;
    
    private void Awake()
    {
        GetComps();
    }

    private void OnEnable()
    {
        playerInputAction.Player.Enable();
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = playerInputAction.Player.Movement.ReadValue<Vector2>();
        playerRigidBody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }

    private void GetComps()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerInputAction = new PlayerInputAction();
    }
}
