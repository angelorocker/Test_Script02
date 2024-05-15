using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private CharacterController cc;
  
    [SerializeField] private float speed = 10f;
    [SerializeField] private float mouseSens = 10f;
    [SerializeField] private Transform head;
    [SerializeField] private float jumpHeight = 9f;

 
    private Vector2 rotationRef;
    private float currentJumpForce;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //per non vedere il cursore
    }
    private void Update()
    {
        Move();
        Rotate(); //mi richiamo rotate in update per dare l'input ogni tot 
    }
    private void Move()
    {
        
        Vector3 jumpVector = transform.up*GetDelta(CalculateJumpForce());
        float totalSpeed;
        if (InputHandler.IsSprinting)
        {
            totalSpeed = speed * 2;
        }
        else
        {
            totalSpeed = speed;
        }
        cc.Move(MovementVector()*GetDelta(totalSpeed) + jumpVector);

    }
    private void Rotate()
    {
       rotationRef += InputHandler.InputRotation* GetDelta(mouseSens);
        rotationRef.y = Mathf.Clamp(rotationRef.y, -90f, 90f);

        transform.localRotation = Quaternion.Euler(0, rotationRef.x, 0);
        head.localRotation = Quaternion.Euler(-rotationRef.y, 0, 0);
    }
    public float CalculateJumpForce()
    {
        if (!cc.isGrounded)
        {
            currentJumpForce -= 1f / jumpHeight;
        }
        else
        {
            if (InputHandler.HasJumped)
            {
                currentJumpForce = jumpHeight;
            }
            
        }
        return currentJumpForce;
    }
    private Vector3 MovementVector() => (transform.right * InputHandler.InputMovement.x) + (transform.forward * InputHandler.InputMovement.y);
    private static float GetDelta(float n) => n * Time.deltaTime;

    }
