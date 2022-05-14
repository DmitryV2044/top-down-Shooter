using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _MoveSpeed = 5f;
    private Vector2 _move;
    public Rigidbody2D _rb;

    private void Update()
    {
        _move.x = Input.GetAxis("Horizontal");
        _move.y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _move * _MoveSpeed * Time.deltaTime);
    }
}
