using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBackground : MonoBehaviour {

    private float speed=4f;
    private float x=0f;
    private float y=10f;
    private float z=157f;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * speed; //background is reversed bc .down doesnt work so its up but upside down X)
        //Debug.Log("Falling stars");
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.transform.position = new Vector3(x, y, z);
       // Debug.Log("It should reset, I guess...");
    }
}
 