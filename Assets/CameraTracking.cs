using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    Vector3 offset;
    public Player player;
    // Use this for initialization
    void Start()
    {
        offset = player.transform.position - transform.position;
        offset.z = -10;
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
