using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask Floor, Whatplayer;

    public Transform[] patrolPath;
    //public float[] waitTimes;
    private int currentPatrolPoint = 0;

    private Vector3 walkPoint;
    private Vector3 target;
    bool walkPointSet;
    private float walkPointRange;

    public float timeBetweenAttacks = 3f;
    bool alreadyAttacked = false;
    public GameObject projectile;

    private bool playerSpotted = false;

    public float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange = false;
    private RaycastHit hit;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Whatplayer);
        //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Whatplayer);
        if (playerInSightRange && !playerInAttackRange) {

            //https://docs.unity3d.com/ScriptReference/Vector3.Dot.html
            //check player is in view, not behind us, through dot prods
            Vector3 forward = Vector3.Normalize(transform.TransformDirection(Vector3.forward));
            Vector3 toPlayer = Vector3.Normalize(player.position - transform.position);

            if ( (Vector3.Dot(forward, toPlayer) > 0.5 ) || playerSpotted)
            {
                if (!playerSpotted)
                {
                    //https://docs.unity3d.com/ScriptReference/Collider.Raycast.html
                    //check LoS
                    Vector3 eyelineOffset = new Vector3(0, 1.40f, 0);
                    Physics.Raycast(transform.position + eyelineOffset, toPlayer, out hit, 30);
                    //Debug.DrawRay(transform.position + eyelineOffset, toPlayer, Color.green, 40);
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject.name == "Player")
                        {
                            playerSpotted = true;
                            print("Spotted player!");
                        }
                    }
                }
           

                if ( playerSpotted)
                {
                    walkPointSet = false;
                    ChasePlayer();
                }
            }
            else
            {
                playerSpotted = false;
                Patroling();
            }

        }
        else
        {
                Patroling();
        }
        
    }

    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        distanceToWalkPoint.y = 0;

        if (distanceToWalkPoint.magnitude < .1f)
        {
            walkPointSet = false;
        }

    }

    private void SearchWalkPoint()
    {
        if(patrolPath == null) {
        }
        if (currentPatrolPoint == patrolPath.Length) {
            currentPatrolPoint = 0;
        }
        walkPoint = patrolPath[currentPatrolPoint].position;
        currentPatrolPoint++;

        agent.SetDestination(walkPoint);


        walkPointSet = true;
        //}
    }



    private void ChasePlayer()
    {
        Vector3 distanceToPlayer = transform.position - player.position;
        if(distanceToPlayer.magnitude > 2f) {
            agent.SetDestination(Vector3.Lerp(transform.position, player.position, .5f));
        }

        AttackPlayer();

        Patroling();
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void AttackPlayer()
    {
        //agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 13f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            player.GetComponentInChildren<PlayerHealth>().TakeDamage(1);
            
        }
    }

}
