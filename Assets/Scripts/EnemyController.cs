using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(27.5f, 3.4f, 2.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.GetComponent<PlayerController2>().Gameover || !Player.GetComponent<PlayerController2>().WinLevel)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

  
}
