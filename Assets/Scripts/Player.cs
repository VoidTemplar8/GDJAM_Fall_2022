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
        transform.position = new Vector3((float)(transform.position.x + Input.GetAxis("Horizontal") / 100), 1, transform.position.z + Input.GetAxis("Vertical") / 100);
    }
}
