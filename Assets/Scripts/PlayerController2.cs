using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody playerRB;    
    private Collider playerColl;

    public Animator playerAmin;
    public GameObject WinLevelPanel;
    public float jumpforce = 5;
    public float gravityModifier = 1.5f;

    public bool Gameover = false;
    public bool isOnGround = false;
    public float speed = 5f;


    private Quaternion playerRotaion;


    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(30, 0.2f, 2.2f);
        playerRB = GetComponent<Rigidbody>();
        playerAmin = GetComponent<Animator>();
        playerColl = GetComponent<Collider>();

        Physics.gravity *= gravityModifier;
        WinLevelPanel.SetActive(false);

        // Player keeps rotating. This sae the initial direction the player is in
        playerRotaion = transform.rotation;


    }

    // Update is called once per frame
    void Update()
    {
        // every frame the is line ensures the player is still pointing in the direction they started in
        transform.rotation =  playerRotaion;

        if (Gameover == false )
        {
            transform.Translate(Vector3.forward  * Time.deltaTime * speed);
        }


        // Function for player jumping
        JumpFunction();

        // Function for player sliding
        SlideFunction();


    }

    //Custom Methode for detecting collision with the obscale and ending the game with aniamtion
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
            
        }
        else if (collision.gameObject.CompareTag("death"))
        {

            Gameover = true;
            

            Debug.Log("Game Over");
        }

        if (collision.gameObject.CompareTag("WinCon"))
        {
            
            StartCoroutine(EnterRiver());            
            Gameover = true;
            StartCoroutine(FinishLevel());
        }


    }


    public void JumpFunction()
    {
        // If statement for jumping on up arrow press and jumping animation trigger
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && Gameover == false)
        {



            playerAmin.SetTrigger("isJumping");
            playerRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnGround = false;

        }

    }

    public void SlideFunction()
    {
        // If statement for sliding animation trigger on arrow key press  
        if (Input.GetKeyDown(KeyCode.DownArrow) && Gameover == false)
        {


            playerAmin.SetTrigger("isSliding");
        }


    }

    IEnumerator EnterRiver()
    {
        playerAmin.SetBool("reachRiver", true);
        
        yield return new WaitForSeconds(0.2f);        
        playerColl.enabled = !playerColl.enabled;

        

    }

    IEnumerator FinishLevel()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
        WinLevelPanel.SetActive(true);
    }
}
