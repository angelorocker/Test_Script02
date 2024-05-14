using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private CharacterController cc; 
    private static Vector2 InputMovement => new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    private static Vector2 InputRotation => new(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

    [SerializeField] private float speed = 10f;
    [SerializeField] private float mouseSens = 10f;
    [SerializeField] private Transform head;
    
    private Vector2 rotationRef;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Move();
        Rotate();
    }
    private void Move()
    {
        cc.Move(MovementVector() * GetDelta(speed));

    }
    private void Rotate()
    {
       rotationRef += InputRotation * GetDelta(mouseSens);
        rotationRef.y = Mathf.Clamp(rotationRef.y, -90f, 90f);

        transform.localRotation = Quaternion.Euler(0, rotationRef.x, 0);
        head.localRotation = Quaternion.Euler(-rotationRef.y, 0, 0);
    }
    private Vector3 MovementVector() => (transform.right * InputMovement.x) + (transform.forward * InputMovement.y);
    private static float GetDelta(float n) => n * Time.deltaTime;
}
