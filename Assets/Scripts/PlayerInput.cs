using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]//Require CharacterController component
public class PlayerInput : MonoBehaviour
{
    private InputAction Move;    
    private InputAction Look;

    [SerializeField] private CharacterController Controller;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField]private float MaxSpeed = 10.0f;
    [SerializeField]private float Gravity = -10.0f;
    [SerializeField]private float RotationSpeed = 40.0f;

    private Vector3 Velocity;

    void Start()
    {
        Move =  InputSystem.actions.FindAction("Player/Move");
        Look = InputSystem.actions.FindAction("Player/Look");
        Controller = GetComponent<CharacterController>();
        if(Controller == null)
        {
            Controller = gameObject.AddComponent<CharacterController>();
        }
        PlayerCamera = GetComponentInChildren<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Move.ReadValue<Vector2>();
        Vector2 look = Look.ReadValue<Vector2>();
        //Move of the player
        Velocity = new Vector3(movement.x, Gravity, movement.y);
        Controller.Move(transform.TransformDirection(Velocity) * MaxSpeed * Time.deltaTime);
    
        //Rotation of the player
        transform.Rotate(Vector3.up, look.x * Time.deltaTime * RotationSpeed);
        PlayerCamera.transform.localRotation *= Quaternion.Euler(-look.y * Time.deltaTime * RotationSpeed, 0, 0);
    }
}
