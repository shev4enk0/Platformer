using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10, jumpforse;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        var inputHorizontalVelosity = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        print(inputHorizontalVelosity); 
        var inputVerticalVelosity = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        var inputDirectionVelosity = new Vector3(inputHorizontalVelosity, inputVerticalVelosity, 0);
        print(inputDirectionVelosity); 
        rb.MovePosition(transform.position + inputDirectionVelosity);
    }
}
