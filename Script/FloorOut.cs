using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorOut : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor") Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor") Destroy(gameObject);
    }
}
