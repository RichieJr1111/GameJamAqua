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

    private void Update()
    {
        WhatShouldPlay();
    }

    // Update is called once per frame
    public void WhatShouldPlay()
    {
        if (Time.timeScale <= 0.5f && Shop.volume == 0f)
        {
            //play shop
            //Shop.mute = false;
            //Battle.mute = true;
            //Plan.mute = true;
            StartCoroutine(SlowTransition(1));
        }
        else if (GameObject.FindGameObjectWithTag("GoodGuy") == null && Plan.volume == 0f && Time.timeScale > 0.25f)
        {
            //play plan
            //Battle.mute = true;
            //Plan.mute = false;
            //Shop.mute = true;
            StartCoroutine(SlowTransition(2));
        }
        else if(GameObject.FindGameObjectWithTag("GoodGuy") != null && Battle.volume == 0f && Time.timeScale > 0.25f)
        {
            //play battle
            //Plan.mute = true;
            //Shop.mute = true;
            //Battle.mute = false;
            StartCoroutine(SlowTransition(3));
        }
    }

    private IEnumerator SlowTransition(int h)
    {
        for (int i = 0; i < 30; i++)
        {
            if (h == 1)
            {
                Shop.volume += 0.01f;
                Battle.volume -= 0.015f;
                Plan.volume -= 0.015f;
            }
            else if (h == 2)
            {
                Plan.volume += 0.01f;
                Battle.volume -= 0.015f;
                Shop.volume -= 0.015f;
            }
            else if (h == 3)
            {
                Plan.volume -= 0.015f;
                Battle.volume += 0.01f;
                Shop.volume -= 0.015f;
            }
            yield return new WaitForSecondsRealtime(0.015f);
        }
    }
}
