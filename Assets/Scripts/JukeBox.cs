using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public static void WhatShouldPlay()
    {
        if (Time.timeScale <= 0)
        {
            //play shop
        }
        else if (GameObject.FindGameObjectWithTag("GoodGuy") == null)
        {
            //play plan
        }
        else
        {
            //play battle
        }
    }
}
