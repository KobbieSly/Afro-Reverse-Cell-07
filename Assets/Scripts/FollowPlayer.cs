using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform target;
    public GameObject Player;
    public float smoothSpeed = 0.04f;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (!Player.GetComponent<PlayerController2>().playerAmin.GetBool("reachRiver"))
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
            transform.position = newPosition;

        }
            

    
    }
}
