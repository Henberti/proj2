using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
//using UnityEngine.UI;

public class hen : MonoBehaviour
{
    public GameObject player;
    public float sightRange = 5;
    public float attackRange = 4;
    public GameObject rocket;
    bool canShot = true;
    public float shootingSpeed = 10f;
    public float enemySpeed = 0.5f;
    private List<GameObject> movingPoints = new List<GameObject>();
    public float ptrolingRange = 3f;
    int currentIdx;
    public GameObject patrolPlane;

    private void Awake()
    {
        player = GameObject.Find("TankPlayer");
        patrolPlane = GameObject.Find("Plane");
    }

    private void Start()
    {   
       
        movingPoints = new List<GameObject>();
        currentIdx = 0;
        Bounds planeBounds = patrolPlane.GetComponent<Renderer>().bounds;

        for (var i = 0; i < 2; i++)
        {
          
            while (true)
            {
                float randomX = Random.Range(-ptrolingRange, ptrolingRange);
                float randomZ = Random.Range(-ptrolingRange, ptrolingRange);
                Vector3 pointPosition = new Vector3(randomX, 0, randomZ);

       
                if (planeBounds.Contains(pointPosition))
                {
       
                    GameObject point = new GameObject("MovingPoint" + i);
                    point.transform.position = pointPosition;

                
                    movingPoints.Add(point);

                    break;
                }
            }
        }
    }




    private void Update()
    {
        float xDistanse = Mathf.Abs(player.transform.position.x - transform.position.x);
        float zDistanse = Mathf.Abs(player.transform.position.x - transform.position.x);

        if(xDistanse< sightRange || zDistanse < sightRange)
            Chasing();


        if (xDistanse < attackRange || zDistanse < attackRange)
            Attacking();

        else Patroling();
               
        
           
        }

    private void Patroling()
    {
        if (transform.position != movingPoints[currentIdx].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, movingPoints[currentIdx].transform.position, enemySpeed * Time.deltaTime);
            transform.LookAt(movingPoints[currentIdx].transform);
        }
        else
            currentIdx = (currentIdx + 1) % 2;
    }

    private void Chasing()
    {
        StartCoroutine(ChasingDelay());
        transform.GetChild(0).transform.LookAt(player.transform);
        transform.position  = Vector3.MoveTowards(transform.position, movingPoints[currentIdx].transform.position, enemySpeed * Time.deltaTime);



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
    


    IEnumerator ShootingDelay(Transform aimingPoint)
    {
        yield return new WaitForSeconds(0.2f);
        var bullet = Instantiate(rocket, aimingPoint.position, aimingPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = aimingPoint.up * shootingSpeed;
        yield return new WaitForSeconds(1.3f);
        canShot = true;
    }
    IEnumerator ChasingDelay()
    {
        yield return new WaitForSeconds(0.2f);
    }


    }
  


    

