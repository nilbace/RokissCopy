using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log("coll");
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("trig");
    }
}
