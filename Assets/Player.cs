using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour
{
    public float speed = 10, jumpforse = 50;
    public LayerMask layer;

    bool faceRight = true;

    Rigidbody rb;
    Vector3 inputDirectionVelosity;
    Vector3 offsetCamera;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        offsetCamera = transform.position - Camera.main.transform.position;
    }


    void FixedUpdate()
    {
        if (IsGrounded())
        {
            FaceAhead();
            Move();
            Jump();
        }
    }

    void Move()
    {
        var inputHorizontalVelosity = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        var inputVerticalVelosity = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        inputDirectionVelosity = new Vector3(inputHorizontalVelosity, inputVerticalVelosity, 0);
        rb.MovePosition(transform.position + inputDirectionVelosity);
    }

    void FaceAhead()
    {
        if (inputDirectionVelosity.x > 0 && !faceRight)
        {
           
            transform.rotation = Quaternion.Euler(0, 0, 0);
            faceRight = !faceRight;
        }
        else if (inputDirectionVelosity.x < 0 && faceRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            faceRight = !faceRight;
        }
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

    void MoveCamera()
    {
        Camera.main.transform.position = transform.position + offsetCamera;
    }
}
