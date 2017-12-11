using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject platform;

    float platformsNumber = 25;

    Vector3 current;

    void Start()
    {
        current = platform.transform.position;
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < platformsNumber; i++)
        {
            var thisPlatform = Instantiate(platform)as GameObject;
            thisPlatform.transform.parent = transform;
            //Range number taken without  calculation
            thisPlatform.transform.position = new Vector2(current.x + Random.Range(8, 17), current.y + Random.Range(-4, 8));
            thisPlatform.transform.rotation = Quaternion.identity;
            current = thisPlatform.transform.position;
        }
       
    }
}
