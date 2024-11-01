using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Controller : MonoBehaviour
{
    public Transform transform;
    public float vel;

    void Start ()
    {
        vel = 10.0f;
        transform = this.GetComponent<Transform>();
    }
    void Update()
    {
        ExecuteInputs();
    }


    void ExecuteInputs()
    {
        Vector3 direccion;
        //direccion = cuerpo.position;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direccion = transform.forward;   
            Walk(direccion);
        }

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direccion = transform.forward * (-1);   
            Walk(direccion);            
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direccion = transform.right * (-1);   
            Walk(direccion);
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direccion = transform.right;  
            Walk(direccion);            
        }
    }

    void Walk(Vector3 dir)
    {
        Vector3 posActual = transform.position;
        transform.position = posActual + (dir * vel * Time.deltaTime); 
    }


}
