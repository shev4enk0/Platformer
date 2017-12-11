using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour
{
    public float speed = 10, jumpforse = 50;
    public LayerMask layer;

    Rigidbody rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if (IsGrounded())
        {
            Move();
            Jump();
        }
    }

    void Move()
    {
        var inputHorizontalVelosity = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        var inputVerticalVelosity = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        var inputDirectionVelosity = new Vector3(inputHorizontalVelosity, inputVerticalVelosity, 0);
        rb.MovePosition(transform.position + inputDirectionVelosity);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpforse, ForceMode.Impulse);
        }

    }

    bool IsGrounded()
    {
        var hit = Physics.Raycast(transform.position, Vector3.down, 0.5f, layer);
        if (hit)
        {
            return true;
        }
            
        return false;
    }
}
