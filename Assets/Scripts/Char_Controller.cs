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

    void Start ()
    {
        vel = 10.0f;
        transform = this.GetComponent<Transform>();
        animator = this.GetComponentInChildren<Animator>();
        isWalking = false;
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

        if(Input.GetKey(KeyCode.Space) )
        {
            if(isJumping == false)
            {
                Jump();
            }
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

        if(dir.magnitude < 0.0001f)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {    
            transform.position += dir * vel * Time.deltaTime;
            animator.SetBool("isWalking", true);
        }
        
    }

    void Jump()
    {
        //Vector3 arriba = Vector3.up;
        //ector3 impulso_salto = arriba * fuerzaSalto;
        //controladorFisicas.velocity = impulso_salto;
        isJumping = true;
        animator.SetBool("isJumping", true); 
    }

    void Attack()
    {
        animator.SetBool("isAttacking", true);

    }

    void OnCollisionEnter(Collision otro_Objeto) 
    {

        //si otro_Objeto contiene el tag Superficie
        if(otro_Objeto.gameObject.CompareTag("piso"))
        {
            //Reseteamos la variable
            isJumping = false;
            animator.SetBool("isJumping", false); 
        }
    }

}
