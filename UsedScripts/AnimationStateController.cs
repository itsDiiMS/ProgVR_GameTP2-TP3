using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationStateController : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Attaques 

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //Zones

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
        animator= GetComponent<Animator>();
        Debug.Log(animator);

    }

    private void Awake()
    {
        player = GameObject.Find("XR Origin").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Idle();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            animator.SetBool("isAttacking", false);
        }

    }



    private void Idle()
    {

        animator.SetBool("isRunning", false);

    }




    private void ChasePlayer()
    {

        agent.SetDestination(player.position);
        animator.SetBool("isRunning", true);

    }
    private void AttackPlayer()
    {

        agent.SetDestination(transform.position);

        transform.LookAt(player);

        animator.SetBool("isAttacking", true);


        if (!alreadyAttacked)
        {
            alreadyAttacked= true;
            Invoke(nameof(ResetAttacks), timeBetweenAttacks);
        }

    }

    private void ResetAttacks()
    {

        alreadyAttacked = false;

    }

}
