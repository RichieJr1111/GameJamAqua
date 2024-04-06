using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class increasestat : MonoBehaviour
{
    public GameObject bioremob1;
    public PlayerAlly biorem1;
    public GameObject bioremob2;
    public GoodExploScript biorem2;
    public GameObject bioremob3;
    public PlayerAlly biorem3;
    public GameObject SpawnerObj;
    public TextMeshProUGUI LevelTXT;
    public TextMeshProUGUI MoneyTXT;
    public TextMeshProUGUI MoneyTXT2;
    public static int Level = 1;
    public static int Money = 0;
    public GameObject[] EnemyPrefabs;
    public GameObject SpeedUpButtons;
    public JukeBox Jukebox;
    // Start is called before the first frame update
    void Start()
    {
        Jukebox = GameObject.Find("Jukebox").GetComponent<JukeBox>();
        biorem1 = bioremob1.transform.GetChild(0).gameObject.GetComponent<PlayerAlly>();
        biorem2 = bioremob2.transform.GetChild(0).gameObject.GetComponent<GoodExploScript>();
    }

    // Update is called once per frame
    void Update()
    {
        LevelTXT.text = Level.ToString();
        MoneyTXT.text = "Currency: " + Money.ToString();
        MoneyTXT2.text = "Currency: " + Money.ToString();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
        {
            Time.timeScale = 0;
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0, 22, -10), 0.0036f);
            GameObject[] goodGuys = GameObject.FindGameObjectsWithTag("GoodGuy");
            foreach (GameObject a in goodGuys)
            {
                Destroy(a.transform.parent.gameObject, 0.1f);
            }
        }
        else
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0, 0, -10), 0.0036f);
        }
    }

    public void IncreaseHealth()
    {
        biorem1.Health++;
        biorem1.MaxHealth++;
    }

    public void NextLevel()
    {
        SpawnerObj.GetComponent<PlayerSpawner>().Reset();
        Jukebox.WhatShouldPlay();
        Time.timeScale = 1f;
        SpeedUpButtons.transform.GetChild(0).gameObject.SetActive(false);
        SpeedUpButtons.transform.GetChild(1).gameObject.SetActive(true);
        SpeedUpButtons.transform.GetChild(2).gameObject.SetActive(false);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
        {
            //spawn enemies
            Level++;
            Time.timeScale = 1;
            switch (Level)
            {
                case 2:
                    for (int i = 0; i < 10; i++) 
                    {
                        Instantiate(EnemyPrefabs[0]);
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        Instantiate(EnemyPrefabs[1]);
                    }
                    break;
                case 3:
                    for (int i = 0; i < 15; i++)
                    {
                        Instantiate(EnemyPrefabs[0]);
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        Instantiate(EnemyPrefabs[1]);
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        Instantiate(EnemyPrefabs[2]);
                    }
                    break;
                case 4:
                    for (int i = 0; i < 0; i++)
                    {
                        Instantiate(EnemyPrefabs[0]);
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        Instantiate(EnemyPrefabs[1]);
                    }
                    for (int i = 0; i < 15; i++)
                    {
                        Instantiate(EnemyPrefabs[2]);
                    }
                    break;
                default:
                    for (int i = 0; i < Level + 10; i++)
                    {
                        Instantiate(EnemyPrefabs[0]);
                    }
                    for (int i = 0; i < Level + 10; i++)
                    {
                        Instantiate(EnemyPrefabs[1]);
                    }
                    for (int i = 0; i < Level + 10; i++)
                    {
                        Instantiate(EnemyPrefabs[2]);
                    }
                    break;
            }
        }
    }
}
