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
        if (Time.timeScale <= 0 && Shop.volume == 0f)
        {
            //play shop
            //Shop.mute = false;
            //Battle.mute = true;
            //Plan.mute = true;
            StartCoroutine(SlowTransition(false, true, true));
        }
        else if (GameObject.FindGameObjectWithTag("GoodGuy") == null && Plan.volume == 0f)
        {
            //play plan
            //Battle.mute = true;
            //Plan.mute = false;
            //Shop.mute = true;
            StartCoroutine(SlowTransition(true, false, true));
        }
        else if(Battle.volume == 0f)
        {
            //play battle
            //Plan.mute = true;
            //Shop.mute = true;
            //Battle.mute = false;
            StartCoroutine(SlowTransition(true, true, false));
        }
    }

    private IEnumerator SlowTransition(bool one, bool two, bool three)
    {
        for (int i = 0; i < 20; i++)
        {
            if (!one)
            {
                Shop.volume += 0.01f;
                Battle.volume -= 0.01f;
            }
            else if (!two)
            {
                Plan.volume += 0.01f;
                Shop.volume -= 0.01f;
            }
            else if (!three)
            {
                Plan.volume -= 0.01f;
                Battle.volume += 0.01f;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
