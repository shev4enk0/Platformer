using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public Player player;

    Vector3 offset;

    void Start()
    {
        offset = player.transform.position - transform.position;
        offset.z = -10;
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
