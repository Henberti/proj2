using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public GameObject target;
    public float chaseRange = 10f;
    public float attackRange = 8f;
    public GameObject rocket;
    public float shootingSpeed = 10f;
    public float patrolingRange = 3f;
    public float enemySpeed = 0.5f;

    NavMeshAgent agent;
    float distanceToEnemy;
    bool canShot = true;
    GameObject plane;
    Vector3 walkPoint;
    bool walkPointSet = false;
    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        plane = GameObject.Find("Plane");
        target = GameObject.Find("TankPlayer");
        distanceToEnemy = Mathf.Infinity;

    } 

    public void Update()
    {
        if (!target) return;
        distanceToEnemy = Vector3.Distance(target.transform.position, transform.position);

        if (distanceToEnemy <= chaseRange) Chasing();
        if (distanceToEnemy <= attackRange) Attacking();
        if (distanceToEnemy > chaseRange) Patroling();

       
    }

    private void Chasing()
    {
        transform.GetChild(0).transform.LookAt(target.transform);

        if (distanceToEnemy >= agent.stoppingDistance)
        {
            agent.speed = enemySpeed * 2;
            agent.SetDestination(target.transform.position);
        }
          
    }

    private void Attacking()
    {
        if (canShot)
        {

            Transform aimingPoint = transform.GetChild(0).GetChild(0).GetChild(0);
            StartCoroutine(ShootingDelay(aimingPoint));
            canShot = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);

    }

    IEnumerator ShootingDelay(Transform aimingPoint)
    {
        yield return new WaitForSeconds(0.2f);
        var bullet = Instantiate(rocket, aimingPoint.position, aimingPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = aimingPoint.up * shootingSpeed;
        yield return new WaitForSeconds(1.3f);
        canShot = true;
    }

    private void Patroling()
    {

        if (!walkPointSet)
            SearchWalkPoint();

        Vector3 disToWalkPoint = transform.position - walkPoint;
   

        if ( disToWalkPoint.magnitude< 2.3f) 
            walkPointSet = false;

        agent.speed = enemySpeed;
        agent.SetDestination(walkPoint);
    

    }

    private void SearchWalkPoint()
    { 
        while (true)
        {
            float rangeCalcX = Mathf.Abs(patrolingRange - transform.position.x);
            float rangeCalcZ = Mathf.Abs(patrolingRange - transform.position.z);
            float randomX = Random.Range(-rangeCalcX, rangeCalcX);
            float randomZ = Random.Range(-rangeCalcZ, rangeCalcZ);

            Bounds planeBounds = plane.GetComponent<Renderer>().bounds;
   


            if (planeBounds.Contains(new Vector3(transform.position.x +randomX, 0, transform.position.z+ randomZ)))
            {
                walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.y+ randomZ);
                walkPointSet = true;
                break;
            }

        }


    }




}
