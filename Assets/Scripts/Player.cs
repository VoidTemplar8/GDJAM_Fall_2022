using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rig;
    public int maxSpeed;
    public int regSpeed;

    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((float)(transform.position.x + Input.GetAxis("Horizontal") / 100), transform.position.y, transform.position.z + Input.GetAxis("Vertical") / 100);
        GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z - 5);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Vehicle")
        {
            rig.AddForce( new Vector3 (100,100,0));
        }
    }
}
