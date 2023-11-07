
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;


    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    float timeBetweenAttacks= 0.001f+(4-Difficult.slideVal)*0.4f;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        if (Difficult.slideVal == 4)
        {
            GetComponent<NavMeshAgent>().speed = 10f;
        }
        player = GameObject.Find("look point").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    public int hp=(int)Difficult.slideVal*5;
    public AudioSource dmg;
    public AudioClip death;
    public int Health
    {
        get { return hp; }
        set {
            if (hp == 1)
            {
                AudioSource.PlayClipAtPoint(death,transform.position);
            }
            else
            {
                dmg.Play();
            }
            hp = value; }
    }
    private void Update()
    {

        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Debug.Log("Patrol");
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
            Debug.Log("Chase");
        }
        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
            //Debug.Log("Atk");
        }
    }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked && Time.timeScale != 0f)
        {
            float accuracy = (1 / Difficult.slideVal) * (1 / Difficult.slideVal);
            if (Difficult.slideVal == 4)
            {
                accuracy *= 0.001f;
            }
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position+transform.forward*0.5f+transform.up*0.3f, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 15f, ForceMode.Impulse);
            rb.AddForce(transform.up * Random.Range(0,23)*0.1f, ForceMode.Impulse);
            rb.AddForce(transform.right * Random.Range(-15f, 15f)*0.1f*accuracy, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    


}
