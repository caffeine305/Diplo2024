using UnityEngine;

public class EnemyAIPhysical : MonoBehaviour
{
    private bool atrapaa;
    private UnityEngine.AI.NavMeshAgent agent;
    public GameObject playerGameObj;
    public Transform player;
    public GameObject wtf;
    public Animator enemyAnimator;
    public float speed;
    void Start()
    {
        atrapaa = false;
        playerGameObj = GameObject.FindGameObjectWithTag("Gatinsky");
        player = playerGameObj.transform;
        wtf = GameObject.FindGameObjectWithTag("Billboard");
        wtf.SetActive(false);
        enemyAnimator = this.GetComponentInChildren<Animator>();
        enemyAnimator.SetBool("isAttacking", false);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.enabled = false;
        if (agent != null)
        {
            agent.speed = speed;
        }
        

    }

   void OnTriggerStay(Collider other)
   {
    if(other.tag == "Gatinsky")
    {
        atrapaa = true;
        wtf.SetActive(true);
        agent.enabled = true;

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
        atrapaa = false;
        wtf.SetActive(false);
        enemyAnimator.SetBool("isAttacking", false);
        agent.enabled = false;
    }
   }

   void OnCollisionEnter(Collision otherCol)
   {
    if(otherCol.gameObject.tag == "Hitbox")
    {
        Destroy(this.gameObject);
    }

    if(otherCol.gameObject.tag == "Gatinsky")
    {
        enemyAnimator.SetBool("isAttacking", true);
    }
   }
   void OnCollisionExit(Collision otherCol)
   {
    if(otherCol.gameObject.tag == "Gatinsky")
    {
        enemyAnimator.SetBool("isAttacking", false);
    }
   }

   void Update()
   {
    if (atrapaa && player != null)
        {
            agent.SetDestination(player.position);
        }
    
    if(Vector3.Distance(transform.position, player.position) < 1.2f)
    {
        agent.enabled = false;
    }
   }

}
