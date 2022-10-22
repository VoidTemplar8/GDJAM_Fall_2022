using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private int speed;
    private Vector3 endPosition;

    void Start()
    {
        speed = Random.Range(CarSpawner.instance.minSpeed, CarSpawner.instance.maxSpeed);
        Debug.Log($"Car Speed is {speed}");
        endPosition = transform.position + transform.forward.normalized * CarSpawner.instance.maxDistance;
        Debug.Log($"Car end position is {transform.forward.normalized * CarSpawner.instance.maxDistance}");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.deltaTime * speed);
    }
}
