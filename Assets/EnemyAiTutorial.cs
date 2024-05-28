
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiTutorial : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    public FieldOfView fov;

    public GameObject warningMark;

    [Header("Audio")]
    public AudioSource attackSource;
    public AudioClip attackClip;

    [Header("Patrolling")]
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    [Header("Atacking")]
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    //public GameObject projectile;

    [Header("States")]
    public float attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public bool isPlayedAudio;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        warningMark.transform.LookAt(player.position);

        //Check for sight and attack range   

        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        

        //calculate the distance from player and enemy

        var distance = Vector3.Distance(agent.transform.position, player.transform.position);

        if (!fov.canSeePlayer && !playerInAttackRange) 
            Patroling();

        if (fov.canSeePlayer && !playerInAttackRange)
        {
            
            ChasePlayer();       
        }


        if (!fov.canSeePlayer && distance <= 6 && !playerInAttackRange)
            
            ChasePlayer();

        if (playerInAttackRange && fov.canSeePlayer) AttackPlayer();
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
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

        warningMark.SetActive(false);
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
        warningMark.SetActive(true);
    }

    private void AttackPlayer()
    {
        

        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);


            attackSource.PlayOneShot(attackClip);
            print("attacking");

            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    
}
