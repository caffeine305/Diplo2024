using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Controller : MonoBehaviour
{
    public PointsManager damageManager;
    public Transform transform;
    public Animator animator;
    public GameObject hitbox;
    public float vel;
    public bool isWalking;
    public bool isJumping;
    //public Rigidbody body;
    public float fuerzaSalto;
    CharacterController characterController;
    public int damageCounter;


    void Start ()
    {
        vel = 7.0f;
        transform = this.GetComponent<Transform>();
        characterController = GetComponent<CharacterController>();
        animator = this.GetComponentInChildren<Animator>();
        //body = GetComponentInChildren<Rigidbody>();
        isWalking = false;
        fuerzaSalto = 1f;
        damageCounter = 1;
        hitbox = GameObject.FindGameObjectWithTag("Hitbox");
        hitbox.SetActive(false);

        GameObject LoadPointsManager = GameObject.FindWithTag("PointsManager");
        if (LoadPointsManager != null)
        {
            damageManager = LoadPointsManager.GetComponent<PointsManager>();
        }
    }

    void Update()
    {
        ExecuteInputs();
    }

    /*
    void LateUpdate()
    {
        Rigidbody rigidbody = GetComponentInChildren<Rigidbody>();
        rigidbody.position = transform.position;
        rigidbody.rotation = transform.rotation;
    }*/

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

        if(hitbox)
        {
            hitbox.SetActive(false);
        }

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

        if(Input.GetKeyDown(KeyCode.P))
        {
            Attack();
        }
        if(Input.GetKeyUp(KeyCode.P) )
        {
            animator.SetBool("isAttacking", false);
        }

    }
    void OnControllerColliderHit(ControllerColliderHit hit)
{
    if (hit.collider.CompareTag("Enemy"))
    {
        Vector3 pushDirection = hit.normal;
        pushDirection.y = 0; // No empujes hacia arriba.
        transform.position += pushDirection * Time.deltaTime * 2f; // Ajusta el valor para evitar overlap.
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
        //body.AddForce(impulsoSalto, ForceMode.Impulse); // Add jump force
        isJumping = true;        
        animator.SetBool("isJumping", true); 
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
        isJumping = false;
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
