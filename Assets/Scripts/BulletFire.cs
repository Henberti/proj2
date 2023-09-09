using System.Collections;
using UnityEngine;


public class BulletFire : MonoBehaviour
{
    private float life = 3;
    [SerializeField] float timeLive = 0.8f;
    ScoreBoard score;
   
    private void Awake()
    {
        Destroy(gameObject, life);
        score = GameObject.Find("Score Board").GetComponent<ScoreBoard>();

    }

    public void Update()
    {
        StartCoroutine(RangeDistroy());
        if (life <= 0)
            Destroy(gameObject);
    }

    IEnumerator RangeDistroy()
    {
        yield return new WaitForSeconds(timeLive);
      
        life--;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("PlayerTank"))
        {
            collision.gameObject.GetComponent<DeathHandler>().HandleDeath();
        }

        if (collision.gameObject.CompareTag("EnemyTank"))
        {
            
            Transform topParent = collision.transform;
            while (topParent.parent != null)
            {
                topParent = topParent.parent;
            }
            score.IncScore();


            Destroy(topParent.gameObject);


        }
        Destroy(gameObject);
    }
   
}