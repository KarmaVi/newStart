using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float _spead = 5f;
    private Vector3 _direction;
    private Vector3 _velocity;
    private float Gravity = -9.8f / 5f;
    private float JumpHeight = 2f;
    private float GroundDistance = 0.2f;
    private CharacterController _characterController;
    private bool _isGrounded = true;
    private Transform _groundChecker;
    private LayerMask Ground;
    private Vector3 Drag;
    private float DashDistance = 5f;


    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _groundChecker = transform.GetChild(0);
    }

    private void Update()
    {
        //_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        Debug.Log(_velocity.y);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _characterController.Move(move * Time.deltaTime * _spead);
        if (move != Vector3.zero)
            transform.forward = move;

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
            //Debug.Log("work");

            if (Input.GetKey(KeyCode.Space))
            {
                //Debug.Log("Space");
                _velocity += Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Drag.x + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * Drag.z + 1)) / -Time.deltaTime)));

            }
            _velocity.y += Gravity * Time.deltaTime;

            _velocity.x /= 1 + Drag.x * Time.deltaTime;
            _velocity.y /= 1 + Drag.y * Time.deltaTime;
            _velocity.z /= 1 + Drag.z * Time.deltaTime;

            _characterController.Move(_velocity * Time.deltaTime);
        }
    }



    //private void FixedUpdate()
    //{
    //    var move = _direction * (_spead * Time.deltaTime);
    //    transform.Translate(move);
    //}
}
