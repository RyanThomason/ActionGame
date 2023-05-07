using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Core : MonoBehaviour
{
    public float coreHealth = 100f;

    public Text coreHealthTxt;


    void Update() {
        coreHealthTxt.text = "Core Health:" + coreHealth.ToString();
    }
    //when an enemy walks into the core it will deal one damage to it
    void OnTriggerEnter(Collider coll) {
        if(coll.gameObject.CompareTag("Enemy")) {
            Destroy(coll.gameObject);
            coreHealth = coreHealth - 1;
        }
    }
}
