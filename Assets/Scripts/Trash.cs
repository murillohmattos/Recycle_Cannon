using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrashType { Plastic, Metal, Organic}
public class Trash : MonoBehaviour
{
    public TrashType trashType;
    public float impulse = 10f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.up * impulse, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Cannon.MyInstance.GainAmmo(trashType);
            Destroy(this.gameObject);
        }
    }
}
