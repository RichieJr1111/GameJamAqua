using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public int currentCount1;
    public int maxCount1;
    public int currentCount2;
    public int maxCount2;
    public GameObject selected;
    public static bool isHoverButton;
    public JukeBox Jukebox;
    // Start is called before the first frame update
    void Start()
    {
        Jukebox = GameObject.Find("Jukebox").GetComponent<JukeBox>();
        currentCount1 = maxCount1;
        currentCount2 = maxCount2;
        //rb = GetComponent<Rigidbody2D>();
    }

    public void Reset()
    {
        currentCount1 = maxCount1;
        currentCount2 = maxCount2;
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selected != null && Time.timeScale != 0 && !isHoverButton)
        {
            switch (selected.name)
            {
                case ("Ally1"):
                    if (currentCount1 > 0)
                    {
                        currentCount1--;
                        GameObject temp = Instantiate(selected, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), selected.transform.rotation);
                        temp.transform.position = new Vector3(temp.transform.position.x, temp.transform.position.y, 0);
                    }
                    else
                    {
                        GetComponent<AudioSource>().Play();
                        //play error sound effect
                    }
                    break;
                case ("GoodExplosion"):
                    if (currentCount2 > 0)
                    {
                        currentCount2--;
                        GameObject temp = Instantiate(selected, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), selected.transform.rotation);
                        temp.transform.position = new Vector3(temp.transform.position.x, temp.transform.position.y, 0);
                        Destroy(temp, 1f);
                    }
                    else
                    {
                        GetComponent<AudioSource>().Play();
                        //play error sound effect
                    }
                    break;
            }
            Jukebox.WhatShouldPlay();
        }
        if (GameObject.FindGameObjectWithTag("GoodGuy") == null && currentCount1 < 0 && currentCount2 < 0)
        {
            //gameOver
        }
    }

    public void SpawnAlly(GameObject ally)
    {
        switch (ally.name)
        {
            case ("Ally1"):
                if (currentCount1 > 0)
                {
                    selected = ally;
                }
                else
                {
                    GetComponent<AudioSource>().Play();
                    //play error sound effect
                }
                break;
            case ("GoodExplosion"):
                if (currentCount2 > 0)
                {
                    selected = ally;
                }
                else
                {
                    GetComponent<AudioSource>().Play();
                    //play error sound effect
                }
                break;
        }
    }
}
