using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Controller : MonoBehaviour
{
    public Transform transform;
    public Animator animator;
    public float vel;
    public bool isWalking;
    public bool isJumping;
    public Rigidbody body;
    public float fuerzaSalto;
    CharacterController characterController;


    void Start ()
    {
        vel = 7.0f;
        transform = this.GetComponent<Transform>();
        characterController = GetComponent<CharacterController>();
        animator = this.GetComponentInChildren<Animator>();
        body = GetComponentInChildren<Rigidbody>();
        isWalking = false;
        fuerzaSalto = 1f;
    }

    void Update()
    {
        ExecuteInputs();
    }


    void ExecuteInputs()
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

        if(Input.GetKeyDown(KeyCode.Space) )
        {
            if(isJumping == false)
            {
                Jump();
            }
        }

        if(Input.GetKeyUp(KeyCode.Space) )
        {
            isJumping = false;        
            animator.SetBool("isJumping", false); 
        }

        if(Input.GetKeyDown(KeyCode.P) )
        {
            Attack();
        }
        if(Input.GetKeyUp(KeyCode.P) )
        {
            animator.SetBool("isAttacking", false);
        }

    }

    void Walk(Vector3 dir)
    {
        //Vector3 posActual = transform.position;

        if(dir.magnitude < 0.001f)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {               
            //Vector3 newPosition = body.position + dir * vel * Time.deltaTime;
            Vector3 newPosition = dir * vel * Time.deltaTime;
            //body.MovePosition(newPosition);
            characterController.Move(newPosition);
            animator.SetBool("isWalking", true);
        }
        
    }

    void Jump()
    {
        Vector3 impulsoSalto = Vector3.up * fuerzaSalto;
        body.AddForce(impulsoSalto, ForceMode.Impulse); // Add jump force
        isJumping = true;        
        animator.SetBool("isJumping", true); 
    }

    void Attack()
    {
        animator.SetBool("isAttacking", true);
    }

 void OnCollisionEnter(Collision collision)
{
    // Ground detection with feet collider
    if (collision.gameObject.CompareTag("piso"))
    {
        isJumping = false;
        animator.SetBool("isJumping", false);
    }
}




}
