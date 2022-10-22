using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rig;
    public float speed;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Vehicle")
        {
            //transform.position = Vector3.zero;
        }
    }
}
