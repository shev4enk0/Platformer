using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour
{
    public float speed = 10, jumpforse = 5;

    //select Ground and attach to the Platform
    public LayerMask layer;

    bool faceRight = true;

    Rigidbody rb;
    Vector3 inputDirectionVelosity;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        FaceAhead();
        Move();
        Jump();
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
        if (Input.GetButtonDown("Jump") && IsGrounded())
            rb.AddForce(Vector3.up * jumpforse, ForceMode.Impulse);
    }

    bool IsGrounded()
    {
        var hit = Physics.Raycast(transform.position, Vector3.down, 0.5f, layer);
        if (hit)
            return true;
        return false;
    }
}
