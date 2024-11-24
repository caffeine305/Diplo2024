using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewChar_Controller : MonoBehaviour
{
    public PointsManager damageManager;
    public Animator animator;
    public GameObject hitbox;
    public float vel;
    private bool isWalking;
    private bool isJumping;
    private bool isAttacking;
    //public Rigidbody body;
    CharacterController characterController;
    public int damageCounter;

    public float jumpForce;
    private Rigidbody rb;
    public BoxCollider gatinskyBoxCol;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        vel = 7.0f;

        animator = this.GetComponentInChildren<Animator>();
        isWalking = false;
        
        damageCounter = 1;
        hitbox = GameObject.FindGameObjectWithTag("Hitbox");
        hitbox.SetActive(false);
        jumpForce = 9f;
        GameObject LoadPointsManager = GameObject.FindWithTag("PointsManager");
        if (LoadPointsManager != null)
        {
            damageManager = LoadPointsManager.GetComponent<PointsManager>();
        }

        GameObject LoadBoxCollider = GameObject.FindWithTag("GatinskyBoxCollider");

        if (LoadBoxCollider != null)
        {
            // Add a BoxCollider if not already present
            gatinskyBoxCol = LoadBoxCollider.GetComponent<BoxCollider>();
        }



    }

    void FixedUpdate()
    {

        Vector3 direccion = Vector3.zero;
        //direccion = cuerpo.position;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direccion += transform.forward;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direccion -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direccion -= transform.right;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direccion += transform.right;
        }

        Walk(direccion.normalized);


    }

    void Update()
    {
        if(!isAttacking)
        {
            hitbox.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Space) )
        {
            if(isGrounded == true)
            {
                Jump();
            }
        }

        if(Input.GetKeyUp(KeyCode.Space) )
        {
            isJumping = false;        
            animator.SetBool("isJumping", false); 
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            Attack();
            isAttacking = true;
        }
        if(Input.GetKeyUp(KeyCode.P) )
        {
            animator.SetBool("isAttacking", false);
            isAttacking = false;
        }

    }


    void Walk(Vector3 dir)
    {
        //Vector3 posActual = transform.position;
        isWalking = true;

        if(dir.magnitude < 0.001f)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {                   
            Vector3 movement = dir * vel;
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
            animator.SetBool("isWalking", true);
        }
    }

    void Jump()
    {
        //Vector3 impulsoSalto = Vector3.up * fuerzaSalto;
        //body.AddForce(impulsoSalto, ForceMode.Impulse); // Add jump force
        animator.SetBool("isJumping", true);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;        
         
    }

    void Attack()
    {
        animator.SetBool("isAttacking", true);
        hitbox.SetActive(true);
    }

 void OnCollisionEnter(Collision collision)
{
    // Ground detection with feet collider
    if (collision.gameObject.CompareTag("piso"))
    {
        isGrounded = true;
        animator.SetBool("isJumping", false);
    }
}
void OnCollisionStay(Collision collision)
{
    if (collision.gameObject.CompareTag("Enemy"))
    {
        damageManager.UpdatePlayerEnergy(damageCounter);
    }


}



}
