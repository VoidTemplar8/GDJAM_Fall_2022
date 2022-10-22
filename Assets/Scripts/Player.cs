using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rig;

    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z - 5);
        if (rig.velocity == new Vector3(0, 0, 0))
        {
            transform.position = new Vector3((float)(transform.position.x + Input.GetAxis("Horizontal") / 100), transform.position.y, transform.position.z + Input.GetAxis("Vertical") / 100);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Vehicle")
        {
            rig.AddForce( new Vector3 (100,100,0));
        }
    }
}
