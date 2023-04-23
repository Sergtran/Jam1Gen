using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public bool isGround = true;

    private float speed = 5.0f;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;

    private Rigidbody playerRb;
    public Animator playerAnimator;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        //this is we get player input
        horizontalInput = Input.GetAxis("Horizontal") * speed;
        verticalInput = Input.GetAxis("Vertical") * speed;

        // move the player
        MoverJugador();

        EjecutarAnimacionCaminar();

        Saltar();

    }

    // collision detection
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        /*
        if(collision.gameObject.CompareTag("reload")){
            transform.position = new Vector3(3, 7,119);
        }
        */
    }

    void MoverJugador()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput);
        transform.Rotate(new Vector3(0f, horizontalInput, 0f).normalized);
    }

    void Saltar()
    {
        // jump the player
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
             playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetBool("Jump", true);
           
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isGround = false;
            playerAnimator.SetBool("Jump", false);
        }
    }

    void EjecutarAnimacionCaminar()
    {
        if (verticalInput == 0 && horizontalInput == 0)
        {
            playerAnimator.SetBool("Walk", false);
        }
        else if (verticalInput != 0 || horizontalInput != 0)
        {
            playerAnimator.SetBool("Walk", true);
        }
    }

}
