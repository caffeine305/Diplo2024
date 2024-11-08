using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    //public PointManager pointManager;
    //public GameObject clickSound;
    //public int looCounter;

    //void Start()
    //{
        //Habrá que ver si se puede hacer puntuajes diferentes por enemigo. Creo que dejando esto sin definir.
        //GameObject LoadPointsManager = GameObject.FindWithTag("PointsManager");
        //if (LoadPointsManager != null)
        //{
        //    pointManager = LoadPointsManager.GetComponent<PointManager>();
        //}
    //}

   void OnTriggerEnter(Collider other)
   {

    if(other.tag == "Gatinsky")
    {
        //pointManager.UpdateLooAmount(looCounter);
        //Instantiate(clickSound,transform.position,transform.rotation);
        Destroy(this.gameObject,0.01f);
        Debug.Log("Memento Obtenido");
    }
   }
}