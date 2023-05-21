using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class vileHugController : MonoBehaviour
{

    private Animator anim;
    public NavMeshAgent Mob;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        //run towards player
        //if(distance)
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay in Sphere");
        Vector3 distanceFromPlayer = other.transform.position - transform.position;
        Debug.Log("Normalized Distance" + distanceFromPlayer.magnitude);

       
        
        Vector3 dirToPlayer = transform.position - player.transform.position;
        Vector3 newPos = transform.position - dirToPlayer;
        Mob.SetDestination(newPos);
        Debug.Log("Player Distance: " + dirToPlayer.magnitude);
        if(distanceFromPlayer.magnitude < 4)
        {

            Debug.Log("Player Distance in the circle: " + dirToPlayer.magnitude);
            anim.Play("HagRun");
            Mob.speed = 2;

        }
        else
        {
            anim.Play("HagWalk");
            Mob.speed = 1;
        }

    }
}
