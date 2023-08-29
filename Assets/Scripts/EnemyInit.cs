using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class EnemyInit : MonoBehaviour
{
    public GameObject[] spanning_zones;
    public GameObject enemy;
    public List<GameObject> enemyList;

    bool canSpawn = true;

    

    private void Awake()
    {
        spanning_zones = GameObject.FindGameObjectsWithTag("spawnzone");
     


        foreach (GameObject _zone in spanning_zones)
        {
   
            Transform zoneTransform = _zone.transform;
           enemyList.Add(Instantiate(enemy, zoneTransform.position, zoneTransform.rotation));
        }

    }
    public void Update()
    {
        if (canSpawn)
        {
            int i = 0;
            foreach (GameObject enemy in enemyList)
            {
                if (enemy == null)
                {
                    canSpawn = false;
                    StartCoroutine(spawnEnemy(i));
                    break;
                }
                i++;
            }
        }
    }


    IEnumerator spawnEnemy(int i)
    {
        yield return new WaitForSeconds(3);
        int randomPosition = Random.Range(0, spanning_zones.Length - 1);
        Transform zoneTransform = spanning_zones[randomPosition].transform;
        enemyList[i] = Instantiate(enemy, zoneTransform.position, zoneTransform.rotation);
        canSpawn = true;


        

    }
}
