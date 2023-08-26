using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletFire : MonoBehaviour
{
    public float life = 3;
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("PlayerTank"))
        {
            restart();
        }

        if (!collision.gameObject.CompareTag("indestructible"))
        {
            
            Transform topParent = collision.transform;
            while (topParent.parent != null)
            {
                topParent = topParent.parent;
            }

            // Destroy the top-most parent, which will destroy all children
            Destroy(topParent.gameObject);


        }
        Destroy(gameObject);
    }
    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}