using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public float playerSpeed = 10;
    private SwipeControls swipeLogic;
    private bool isOnGround = false;
    public float jumpForce = 20;
    public GameObject graphics;
    private Animator anims;
    // Start is called before the first frame update
    void Start()
    {
        anims = graphics.GetComponent<Animator>();
        anims.SetBool("isRunning", true);
        anims.SetBool("isJumping", true);
        swipeLogic = (SwipeControls)transform.GetComponent(typeof(SwipeControls));
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        gameObject.transform.Translate(Vector3.left * playerSpeed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        swipeControls();
    }

    public void swipeControls()
    {
        var direction = swipeLogic.getSwipeDirection();
        if (isOnGround = true && direction == SwipeControls.SwipeDirection.Jump)
        {
            isOnGround = false;
            rb.velocity = new Vector3(0, jumpForce, 0);
            //Gravity Scale in Unity Rigibdody Component should be set to 5
        }else if (isOnGround = true && direction == SwipeControls.SwipeDirection.Duck)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            Invoke("Up", 3);
            anims.SetBool("isSliding", true);
        }
    }

    public void Up()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        anims.SetBool("isSliding", false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
            anims.SetBool("isJumping", false);
        }
    }
}
