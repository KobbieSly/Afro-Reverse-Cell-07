using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 SpawnPos = new Vector3 Random.Range((-10,-50), 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    
     
    private PlayerController playerControllerScript;
   // private PlayerController Player;
   
    
    // Start is called before the first frame update
    void Start()
    {

       
        
        InvokeRepeating( "SpawnObstacle", startDelay, repeatRate);
        
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
         
    }

    private void SpawnObstacle()
    {

        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, SpawnPos, obstaclePrefab.transform.rotation);

           
        }

    }

    

}
