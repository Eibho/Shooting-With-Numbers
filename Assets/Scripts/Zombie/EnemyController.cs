using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyController : MonoBehaviour {

    public float distanceFrom = 10f;

    private Vector3 enemyTarget;
    public float enemyRotation;

    Transform player;
    NavMeshAgent navAgent;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        navAgent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {

        float distance = Vector3.Distance(player.position, transform.position);

        if(distance <= distanceFrom)
        {
            navAgent.SetDestination(player.position);
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanceFrom);
    }
}
