using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody playerRB;
    private Collider playerColl;

    public BoxCollider Pcollider;
    public Animator playerAmin;
    public GameObject WinLevelPanel;
    //public GameObject PlayerDeathPanel;
    public float jumpforce = 3500;
    public float gravityModifier = 10;

    public bool Gameover;
    public bool WinLevel;
    public bool isOnGround = false;
    public float speed = 3;
    const float ySize = 0.2f;


    private Quaternion playerRotaion;


    // Start is called before the first frame update

    private void Awake()
    {
        Physics.gravity = new Vector3(0, -9.8F, 0);
        Physics.gravity *= gravityModifier;
    }
    void Start()
    {
        
        Gameover = false;
        WinLevel = false;

        // Player keeps rotating. This saves the initial direction the player is pointing to stop rotation
        playerRotaion = transform.rotation;

        transform.position = new Vector3(19, 0.2f, 2.2f);
        playerRB = GetComponent<Rigidbody>();
        playerAmin = GetComponent<Animator>();
        playerColl = GetComponent<Collider>();
        Pcollider = GetComponent<BoxCollider>();


        


    }

    // Update is called once per frame
    void Update()
    {


        if (!Gameover || !WinLevel)
        {
            // every frame this line ensures the player is still pointing in the direction they started in
            transform.rotation = playerRotaion;

            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            // Function for player jumping
            JumpFunction();

            // Function for player sliding
            SlideFunction();

        }
    }

    //Custom Methode for detecting collision with the obstacle and ending the game with aniamtion
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;

        }// Methode for detecting collision with the enemy and calling gameover screen
        else if (collision.gameObject.CompareTag("death"))
        {

            Gameover = true;
            //PlayerDeathPanel.SetActive(true);
            Debug.Log("Game Over");
        } else if (collision.gameObject.CompareTag("WinCon"))
        {

            StartCoroutine(EnterRiver());
            StartCoroutine(FinishLevel());
        }


    }


    public void JumpFunction()
    {
        // If statement for jumping on up arrow press and jumping animation trigger
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && Gameover == false)
        {


            playerAmin.ResetTrigger("isJumping");
            playerAmin.SetTrigger("isJumping");
            playerRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnGround = false;

        }

    }

    public void SlideFunction()
    {
        // If statement for sliding animation trigger on arrow key press  
        if (Input.GetKeyDown(KeyCode.DownArrow) && !Gameover)
        {
            float origSizey = Pcollider.size.y;
            float origCentery = Pcollider.center.y;


            Pcollider.size = new Vector3(Pcollider.size.x, ySize, Pcollider.size.z);
            Pcollider.center = new Vector3(Pcollider.center.x, 0.1f, Pcollider.center.z);

            playerAmin.SetTrigger("isSliding");

            StartCoroutine(SetCollider(origSizey , origCentery));
            //collider.size = new Vector3(collider.size.x, origSizey, collider.size.z);
            // collider.center = new Vector3(collider.center.x, origCentery, collider.center.z);


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
        yield return new WaitForSeconds(3);
        WinLevel = true;
        Gameover = true;
        
    }

    IEnumerator SetCollider(float origSizey , float origCentery)
    {
        yield return new WaitForSeconds(1.2f);
        Pcollider.size = new Vector3(Pcollider.size.x, origSizey, Pcollider.size.z);
        Pcollider.center = new Vector3(Pcollider.center.x, origCentery, Pcollider.center.z);
    }


}
