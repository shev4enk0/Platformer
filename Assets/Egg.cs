using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Egg : MonoBehaviour
{
    public event Action BrokenEgg;
    public event Action CathedEgg;

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Ground")
        {
            print("Ground"); 
            if (BrokenEgg != null)
                BrokenEgg();
        }
           
        if (other.collider.tag == "Hat")
        {
            print("Hat"); 
            if (CathedEgg != null)
                CathedEgg();
        }
           
    }
}
