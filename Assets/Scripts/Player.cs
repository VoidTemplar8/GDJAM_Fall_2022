using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine;
using JetBrains.Annotations;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rig;
    public bool gameActive = true;

    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z - 5);
        if (rig.velocity == new Vector3(rig.velocity.x, 0, rig.velocity.z) && gameActive)
        {
            rig.velocity = Vector3.zero;
            transform.position = new Vector3((float)(transform.position.x + Input.GetAxis("Horizontal") / 100), transform.position.y, transform.position.z + Input.GetAxis("Vertical") / 100);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (!gameActive)
        {
            GameObject.Find("Dim").transform.position = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z - 5);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Ground" && transform.rotation == Quaternion.Euler(new Vector3(0, 0, 0)))
        {
            rig.freezeRotation = true;
        }
        if (collision.transform.tag == "Vehicle")
        {
            rig.freezeRotation = false;
            rig.AddForce( new Vector3 (100, 100, rig.velocity.z));
        }
        if (collision.transform.tag == "Finish")
        {
            rig.freezeRotation = false;
            rig.AddForce(new Vector3(0, 0, -1));
            gameActive = false;
        }
    }
}
