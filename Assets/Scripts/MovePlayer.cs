using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public bool isGround = true;

    private float speed = 5.0f;
    private float horizontalInput;
    private float forwardInput;

    private Rigidbody playerRb;
    private Animator playerAnimator;

    Vector3 newRotation = new Vector3(0, 10, 0);

    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        //this is we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // move the player
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        if(Input.GetKeyDown(KeyCode.UpArrow) 
        || Input.GetKeyDown(KeyCode.DownArrow)
        || Input.GetKeyDown(KeyCode.LeftArrow)
        || Input.GetKeyDown(KeyCode.RightArrow)
        || Input.GetKeyDown(KeyCode.W)
        || Input.GetKeyDown(KeyCode.S)
        || Input.GetKeyDown(KeyCode.A)
        || Input.GetKeyDown(KeyCode.D))
        {
            playerAnimator.SetBool("Walk", true);
        }




        if(Input.GetKeyDown(KeyCode.R)){
            transform.eulerAngles = newRotation;
        }

        // jump the player
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
        }
        
    }

    // collision detection
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground")){
        isGround = true;
        }
        if(collision.gameObject.CompareTag("reload")){
            transform.position = new Vector3(3, 7,119);
        }
    }

}
