using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine;
using JetBrains.Annotations;
using UnityEditor;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rig;
    public bool gameActive = true;
    Vector3 buttonPos1, buttonPos2;

    void Start()
    {
        buttonPos1 = GameObject.Find("Back to menu").transform.position;
        GameObject.Find("Back to menu").transform.position = new Vector3 (0,-300, 0);
        buttonPos2 = GameObject.Find("Replay").transform.position;
        GameObject.Find("Replay").transform.position = new Vector3(0, -300, 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z - 5);
        if (Input.GetKeyUp(KeyCode.Space) && rig.velocity == new Vector3(0, 0, 0))
        {
            rig.freezeRotation = false;
            rig.velocity = new Vector3(Input.GetAxis("Horizontal"), 1, Input.GetAxis("Vertical"));
            rig.AddForce(new Vector3(Input.GetAxis("Horizontal") * 1000, 100, Input.GetAxis("Vertical") * 1000));
            transform.rotation = Quaternion.Euler(new Vector3(-Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal")));
        }
        if (rig.velocity == new Vector3(rig.velocity.x, 0, rig.velocity.z) && gameActive)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            rig.velocity = Vector3.zero;
            transform.position = new Vector3((float)(transform.position.x + Input.GetAxis("Horizontal") / 50), transform.position.y, transform.position.z + Input.GetAxis("Vertical") / 50);
        }
        if (!gameActive)
        {
            GameObject.Find("Dim").transform.position = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z - 5);
            GameObject.Find("Back to menu").transform.position = buttonPos1;
            GameObject.Find("Replay").transform.position = buttonPos2;
            GameObject.Find("Timer").transform.position = new Vector3(0, -300, 0);
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
            rig.AddForce( new Vector3 (100, 100, rig.velocity.z - 100));
        }
        if (collision.transform.tag == "Bounds")
        {
            rig.freezeRotation = false;
            rig.AddForce(new Vector3(0, 0, 1));
        }
        if (collision.transform.tag == "Finish")
        {
            rig.freezeRotation = false;
            rig.AddForce(new Vector3(0, 0, -1));
            gameActive = false;
        }
    }
}
