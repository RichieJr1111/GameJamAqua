using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeBox : MonoBehaviour
{
    public AudioSource Battle;
    public AudioSource Plan;
    public AudioSource Shop;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public void WhatShouldPlay()
    {
        if (Time.timeScale <= 0 && !Shop.isPlaying)
        {
            //play shop
            Battle.Stop();
            Plan.Stop();
        }
        else if (GameObject.FindGameObjectWithTag("GoodGuy") == null && !Plan.isPlaying)
        {
            //play plan
            Plan.Play();
            Battle.Stop();
        }
        else if(!Battle.isPlaying)
        {
            //play battle
            Battle.Play();
            Plan.Stop();
        }
    }
}
