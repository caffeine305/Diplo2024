using UnityEngine;

public class GetItem : MonoBehaviour
{
    public PointsManager pointManager;
    //public GameObject clickSound;
    public int scoreCounter;

    void Start()
    {
        GameObject LoadPointsManager = GameObject.FindWithTag("PointsManager");
        if (LoadPointsManager != null)
        {
            pointManager = LoadPointsManager.GetComponent<PointsManager>();
        }
        scoreCounter = 1;
    }

   void OnTriggerEnter(Collider other)
   {

    if(other.tag == "Gatinsky")
    {
        pointManager.UpdatePoints(scoreCounter);
        //Instantiate(clickSound,transform.position,transform.rotation);
        Destroy(this.gameObject,0.01f);
        //Debug.Log("Memento Obtenido");
    }
   }
}