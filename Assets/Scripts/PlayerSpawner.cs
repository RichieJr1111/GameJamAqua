using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSpawner : MonoBehaviour
{
    public int currentCount1;
    public int maxCount1;
    public int currentCount2;
    public int maxCount2;
    public GameObject selected;
    public static bool isHoverButton;
    public JukeBox Jukebox;
    public TextMeshProUGUI c1;
    public TextMeshProUGUI c2;
    public TextMeshProUGUI c3;
    public GameObject FadeObj;
    public GameObject GameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        currentCount1 = maxCount1;
        currentCount2 = maxCount2;
        Jukebox = GameObject.Find("Jukebox").GetComponent<JukeBox>();
        StartCoroutine(Transition());
        //rb = GetComponent<Rigidbody2D>();
    }

    private IEnumerator Transition()
    {
        for (int i = 0; i < 100; i++)
        {
            FadeObj.GetComponent<Image>().color -= new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
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
        c1.text = currentCount1.ToString();
        c2.text = currentCount2.ToString();
        c3.text = currentCount2.ToString();
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
            Jukebox = GameObject.Find("Jukebox").GetComponent<JukeBox>();
            Jukebox.WhatShouldPlay();
        }
        if (GameObject.FindGameObjectWithTag("GoodGuy") == null && currentCount1 <= 0 && currentCount2 <= 0)
        {
            //gameOver
            StartCoroutine(GameOverScreen.GetComponent<GameOverFade>().Fade());
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
