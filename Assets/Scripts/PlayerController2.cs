using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAmin;

    public float jumpforce = 5;
    public float gravityModifier = 1.5f;

    public bool Gameover = false;
    public bool isOnGround = false;
    public float speed = 5f;


    private Quaternion playerRotaion;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAmin = GetComponent<Animator>();

        Physics.gravity *= gravityModifier;

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
       /* else if (collision.gameObject.CompareTag("obstacle"))
        {

            Gameover = true;
            //playerAmin.SetBool("Death_b", true);
            //playerAmin.SetInteger("DeathType_int", 1);

            Debug.Log("Game Over");
        }*/
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
}
