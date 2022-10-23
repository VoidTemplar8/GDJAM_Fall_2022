using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text text;
    public Player player;
    public float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        //you get one minute
        //Its 11:59 and someone just ordered a pizza for same day delivery, now you must hurry to deliver the pizza. Watch out for cars!
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameActive)
        {
            elapsedTime += Time.deltaTime;
            if (60 - Math.Floor(elapsedTime) != 60)
            {
                text.text = $"Time: {60 - Math.Floor(elapsedTime)}";
            }
        }
    }
}
