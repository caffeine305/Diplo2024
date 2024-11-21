using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billy : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(27.25f,Camera.main.transform.eulerAngles.y,0f); //el  es para que cheque con la orientación de la cámara.
    }
}
