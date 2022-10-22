using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody rig;
    public int speed;
    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
        rig = GetComponent<Rigidbody>();
        speed = Random.Range(CarSpawner.instance.minSpeed, CarSpawner.instance.maxSpeed);
        rig.AddForce(transform.forward * speed, ForceMode.Impulse);
        Debug.Log(rig.velocity);
    }

    private void Update()
    {
        
        if ((transform.position - startingPosition).magnitude > CarSpawner.instance.maxDistance)
        {
            RestartCar();
        }
    }

    private void RestartCar()
    {
        rig.velocity = Vector3.zero;
        if (transform.parent.IsUnityNull())
        {
            transform.position = transform.position - transform.forward.normalized * CarSpawner.instance.maxDistance;
        } else
        {
            transform.localPosition = Vector3.zero;
        }
        speed = Random.Range(CarSpawner.instance.minSpeed, CarSpawner.instance.maxSpeed);
        rig.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
