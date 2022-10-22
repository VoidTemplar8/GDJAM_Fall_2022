using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public static CarSpawner instance;
    public GameObject carPrefab;
    public List<GameObject> spawnLocations;
    public int maxDistance;
    public int maxSpeed;
    public int minSpeed;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        foreach (GameObject spawnlocation in spawnLocations)
        {
            Instantiate(carPrefab, spawnlocation.transform.position, spawnlocation.transform.rotation);
        }
    }
}
