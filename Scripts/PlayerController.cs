using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public float jumpForce;
    public float gravityScale = 5f;
    public float rotateSpeed;

    private bool doubleJump;

    private Vector3 moveDirection;

    public CharacterController charController;
    private Camera theCam;

    public GameObject playerModel;
    public Animator anime;
    public ParticleSystem jump;

    public bool isKnocked, isKnockedS;
    public float knockedBackL = .3f;
    public float knockedBackS = 1f;
    private float knockedBackCounter;
    public Vector2 knockBackPower,knockedUpPower;


    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        jump.Stop();
        theCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
            
            PlayerMovement();
              isJumping();

    }
    

    void PlayerMovement()
        {
            if (!isKnocked)
            {
                   float yStore = moveDirection.y;

                      //moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
                  moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal")); ;
                  moveDirection.Normalize();
                  moveDirection = moveDirection * moveSpeed;
                  moveDirection.y = yStore;

                   if (charController.isGrounded && !Input.GetButton("Jump"))
                    {
                         moveDirection.y = 0f;

                        //jump.Play();
                         doubleJump = false;
                         gravityScale = 5f;
                

                    }

                    if (charController.isGrounded || doubleJump == true)
                    {

                          if (Input.GetButtonDown("Jump"))
                         {
                               jump.Play();
                               moveDirection.y = jumpForce;
                               doubleJump = !doubleJump;
                    
                          }
                    }
                      if (Input.GetButton("Jump") && doubleJump == false)
                     {
                          gravityScale = 3.25f;
                     }




                   moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

                    //transform.position = transform.position + (moveDirection * Time.deltaTime);
                       charController.Move(moveDirection * Time.deltaTime);

                 if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                 {
                    transform.rotation = Quaternion.Euler(0f, theCam.transform.rotation.eulerAngles.y, 0f);
                    Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
                    //playerModel.transform.rotation = newRotation;
                    playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
                 }

            }

        if (isKnocked)
        {
            knockedBackCounter -= Time.deltaTime;

            float yStore = moveDirection.y;
            moveDirection = playerModel.transform.forward * -knockBackPower.x;
            moveDirection.y = yStore;

            if (charController.isGrounded )
            {
               gravityScale = 0f;
            }

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            charController.Move(moveDirection * Time.deltaTime);
        }
     
        if (knockedBackCounter <= 0)
        
        {
                      isKnocked = false;
                  
        }
        ///
        if (isKnockedS)
        {
            knockedBackCounter -= Time.deltaTime;

            float yStore = moveDirection.y;
            //moveDirection = playerModel.transform.forward * -knockBackPower.y;
            moveDirection.y = yStore;

            if (charController.isGrounded)
            {
                gravityScale = 0f;
            }

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            charController.Move(moveDirection * Time.deltaTime);
        }

        if (knockedBackCounter <= 0)

        {
            isKnockedS = false;

        }
        //
        anime.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        anime.SetBool("Grounded", charController.isGrounded);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            KnockedBack();
        }
        if (other.tag == "Shroom")
        {
            SKnockedBack();
        }
        if (other.tag == "Boss")
        {
            KnockedBack();
        }

    }
    public void KnockedBack()
    { 
        isKnocked = true;
        knockedBackCounter = knockedBackL;
        Debug.Log("Knocked");
    }

    public void SKnockedBack()
    {
        isKnockedS = true;
        knockedBackCounter = knockedBackS;
        Debug.Log("Knocked");
    }
    public void isJumping()
    {
        if (charController.isGrounded)
        jump.Stop();
    }

    
}
