using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public GameObject vfxCore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyController enemy = other.GetComponent<EnemyController>();

            GameObject instance = Instantiate(vfxCore, transform.position, vfxCore.transform.rotation);
            Destroy(instance, 2f);

            GameManager.MyInstance.CoreTakeDamage();
            Destroy(enemy.gameObject);
        }
    }

    
}
