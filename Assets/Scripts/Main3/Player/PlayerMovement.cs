using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    public Animator anim;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _texture;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    public Joystick joystick2;
    public GameObject kryg;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _texture = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }

    public Vector2 moveVector;

    private void SetPlayerVelocity()
    {
        // if ()//УСЛОВИЕ С КНОПКОЙ
        // {
        //     _smoothedMovementInput.x = joystick2.Horizontal;
        //     _smoothedMovementInput.y = joystick2.Vertical;
        // }
        // else 
        // {
        //     Destroy(joystick2);
        //     kryg.SetActive(false);

        //     _smoothedMovementInput = Vector2.SmoothDamp(
        //         _smoothedMovementInput, 
        //         _movementInput, 
        //         ref _movementInputSmoothVelocity, 
        //         0.1f);
        // }
        if ((joystick2.Horizontal == 0) && (joystick2.Vertical == 0))
        {
            _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput, 
            _movementInput, 
            ref _movementInputSmoothVelocity, 
            0.1f);
        }

        else
        {
            _smoothedMovementInput.x = joystick2.Horizontal;
            _smoothedMovementInput.y = joystick2.Vertical;
        }
        _rigidbody.velocity = _smoothedMovementInput * _speed;
        
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        anim.SetFloat("moveY", Mathf.Abs(moveVector.y));
    }


    private void RotateInDirectionOfInput()
    {
        if ((_movementInput != Vector2.zero) || (_smoothedMovementInput.x != 0) || (_smoothedMovementInput.y != 0))
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
