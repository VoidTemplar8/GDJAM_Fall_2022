using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Title()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void Reset()
    {
        SceneManager.LoadScene("Game");
    }
}
