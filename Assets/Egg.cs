using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Egg : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Ground")
            Destroy(gameObject);
        if (other.collider.tag == "Hat")
            Destroy(gameObject);
    }
}
