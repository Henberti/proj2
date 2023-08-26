using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUi : MonoBehaviour
{
    public GameObject heart;
    public int lifeCount = 3;
    public List<GameObject> heartList = new List<GameObject>();
    public float xPadding = 0;


    public void Start()
    {
        for(var i=0; i<lifeCount; i++)
        {
            GameObject heartInstence = Instantiate(heart, transform.position + new Vector3(xPadding, 0, 0), transform.rotation);
            xPadding += 4;
            heartInstence.SetActive(true);
        }
    }


}
