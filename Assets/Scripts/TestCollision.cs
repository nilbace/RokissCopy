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

    private void Update() {
        Debug.DrawRay(transform.position, Vector3.forward*10, Color.red);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.forward, out hit, 10))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
