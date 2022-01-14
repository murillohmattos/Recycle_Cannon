using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject collisionVFX;
    public TrashType bulletType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyController enemy = other.GetComponent<EnemyController>();

            if (enemy.type != bulletType)
            {
                other.GetComponent<EnemyController>().TakeDamage(Cannon.MyInstance.bulletDamage);
            }

            GameObject vfxTMP = Instantiate(collisionVFX, transform.position, transform.rotation);
            Destroy(vfxTMP, 2f);

            Destroy(this.gameObject);
        }
    }
}
