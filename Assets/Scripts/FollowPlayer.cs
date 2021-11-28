using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform targetFollow;
    public GameObject Player;
    public float smoothSpeed = 0.04f;

    private Vector3 offset;
    private bool gameover;
    private bool levelWon;

    void Start()
    {
        transform.position = new Vector3(19f, 5.4f, -3.7f);
        offset = transform.position - targetFollow.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameover = Player.GetComponent<PlayerController2>().Gameover;
        levelWon = Player.GetComponent<PlayerController2>().WinLevel;
        if (!gameover || !levelWon)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, targetFollow.position + offset, smoothSpeed);
            transform.position = newPosition;

        }
            

    
    }


    

}
