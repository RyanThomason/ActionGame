using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    void OnTriggerEnter(Collider coll) {
        if(coll.gameObject.CompareTag("Enemy")) {
            Destroy(coll.gameObject);
        }
    }
}
