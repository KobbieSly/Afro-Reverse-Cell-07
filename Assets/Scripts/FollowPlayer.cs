using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float cameraSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 camPos = transform.position;
        camPos.x = player.transform.position.x;
        transform.position = Vector3.Lerp(transform.position, camPos, 3 * Time.fixedDeltaTime);

        camPos.y = player.transform.position.y;
        transform.position = Vector3.Lerp(transform.position, camPos, 3 * Time.fixedDeltaTime);
        
        camPos.z = player.transform.position.z;
        transform.position = Vector3.Lerp(transform.position, camPos, 3 * Time.fixedDeltaTime);
    }
}
