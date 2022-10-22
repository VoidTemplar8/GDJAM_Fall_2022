using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((float)(transform.position.x + Input.GetAxis("Horizontal") / 100), 1, transform.position.z + Input.GetAxis("Vertical") / 100);
        GameObject.Find("Main Camera").transform.position = new Vector3((float)(GameObject.Find("Main Camera").transform.position.x + Input.GetAxis("Horizontal") / 100), 5, GameObject.Find("Main Camera").transform.position.z + Input.GetAxis("Vertical") / 100);
    
        
    
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Vehicle")
        {
            transform.position = Vector3.zero;
        }
    }
}
