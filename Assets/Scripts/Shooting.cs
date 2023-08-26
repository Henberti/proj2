using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform roketSpawnPoint;
    public GameObject Rocket;
    public float shootingSpeed = 10f;
    bool canShot = true;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (canShot)
            {
                var bullet = Instantiate(Rocket, roketSpawnPoint.position, roketSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = roketSpawnPoint.up * shootingSpeed;
                canShot = false;
                StartCoroutine(shootDelay());
            }
           
        }
    }
    IEnumerator shootDelay()
    {
        yield return new WaitForSeconds(1.5f);
        canShot = true;

    }

}
