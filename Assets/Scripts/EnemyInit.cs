using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyInit : MonoBehaviour
{
    public GameObject[] spanning_zones;
    public GameObject enemy;

    

    private void Awake()
    {
        spanning_zones = GameObject.FindGameObjectsWithTag("spawnzone");
  
        foreach (GameObject _zone in spanning_zones)
        {
   
            Transform zoneTransform = _zone.transform;
            Instantiate(enemy, zoneTransform.position, zoneTransform.rotation);
        }

    }
}
