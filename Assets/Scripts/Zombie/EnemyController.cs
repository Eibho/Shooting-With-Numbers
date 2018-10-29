using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyController : MonoBehaviour {

    public float distanceFrom = 10f; //distance from the player

    private Vector3 enemyTarget;
    public float enemyRotation;

    Transform player;
    NavMeshAgent navAgent;

    //private ZombieAnimator m_zom;
   // private Animator m_animator;
   // private float m_forward;

	
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        navAgent = GetComponent<NavMeshAgent>();

        // m_zom = GetComponent<ZombieAnimator>();
       // m_animator = GetComponent<Animator>();



    }
	
	void Update () {

        float distance = Vector3.Distance(player.position, transform.position);

        

        if(distance <= distanceFrom)
        {
          
            navAgent.SetDestination(player.position); 
            //face player
            FacePlayer(); 
        }

	}
    
    void FacePlayer()
    {
        enemyTarget = new Vector3(player.position.x + enemyRotation, transform.position.y, transform.position.z);


        transform.LookAt(player);


        transform.Rotate(new Vector3(0, 90f, 0));
    }

    private void OnDrawGizmosSelected()
    {
        //draw sphere to show distance from which enemy can view player
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanceFrom);
    }
}
