using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIPhysical : MonoBehaviour
{
    private bool atrapaa;
    public GameObject wtf;
    void Start()
    {
        atrapaa = false;
        wtf = GameObject.FindGameObjectWithTag("Billboard");
        wtf.SetActive(false);
    }

   void OnTriggerStay(Collider other)
   {
    if(other.tag == "Gatinsky")
    {
        atrapaa = true;
        wtf.SetActive(true);

        if(atrapaa)
        {
            Debug.Log("¡Atrapá, Gatinsky!");
        }
    }
   }

   void OnTriggerExit(Collider other)
   {
    if(other.tag == "Gatinsky")
    {
        wtf.SetActive(false);
    }
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
