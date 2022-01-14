using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{    
    public Enemy enemyData;
    NavMeshAgent agent;
    public Transform target;
    int enemyLife;
    public TrashType type;
    public GameObject trash;

    public int EnemyLife { get => enemyLife; set => enemyLife = value; }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        target = GameObject.Find("Core").transform;

        agent.speed = enemyData.speed;
        EnemyLife = enemyData.life;
        type = enemyData.enemyType;

        // Update is called once per frame
        
    }

    void Update()
    {
        agent.SetDestination(target.position);        
    }

    public void TakeDamage(int amount) 
    {
        enemyLife -= amount;

        if (EnemyLife <= 0)
        {
            StartCoroutine(TrashDrop());

            Destroy(this.gameObject, 0.25f);
        }
    }

    IEnumerator TrashDrop(int amount = 2) 
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject trashInstance = Instantiate(trash, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.15f);
        }        
    }
}