using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    public int increaseHealthPrice = 5;
    public int increaseCountPrice = 5;
    public int increaseDamagePrice = 5;
    public GameObject[] UpgradeTabs;
    public int[] BoughtCountHealth;
    public int[] BoughtCountCount;
    public int[] BoughtCountDamage;
    private bool GlobalOne = false;
    private bool GlobalTwo = false;
    private bool GlobalThree = false;
    private bool GlobalFour = false;
    //public TextMeshProUGUI cost1;
    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        biorem1 = bioremob1.transform.GetChild(0).gameObject.GetComponent<PlayerAlly>();
        biorem2 = bioremob2.GetComponent<GoodExploScript>();
        Jukebox = GameObject.Find("Jukebox").GetComponent<JukeBox>();
        Camera.main.transform.position = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        LevelTXT.text = Level.ToString();
        MoneyTXT.text = "Research Points: " + Money.ToString();
        MoneyTXT2.text = "Research Points: " + Money.ToString();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
        {
            //add here
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0, 22, -10), 2f * Time.unscaledDeltaTime);
            GameObject[] goodGuys = GameObject.FindGameObjectsWithTag("GoodGuy");
            foreach (GameObject a in goodGuys)
            {
                Destroy(a.transform.parent.gameObject);
            }
            GameObject[] Explo = GameObject.FindGameObjectsWithTag("Explo");
            foreach (GameObject b in Explo)
            {
                Destroy(b);
            }
            Time.timeScale = 0;
        }
        else
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0, 0, -10), 2f * Time.unscaledDeltaTime);
        }
    }

    public void IncreaseHealth(int w)
    {

        if (Money >= increaseHealthPrice * (BoughtCountHealth[w] + 1))
        {
            Money -= increaseHealthPrice * (BoughtCountHealth[w] + 1);
            if (w == 0)
            {
                biorem1.MaxHealth++;
                biorem1.Health++;
                BoughtCountHealth[w]++;
                if (GlobalTwo)
                {
                    biorem1.MaxHealth++;
                    biorem1.Health++;
                }
            }
            else
            {
                biorem3.MaxHealth++;
                biorem3.Health++;
                BoughtCountHealth[w]++;
                if (GlobalTwo)
                {
                    biorem3.MaxHealth++;
                    biorem3.Health++;
                }
            }
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Cost : " + (increaseHealthPrice * (BoughtCountHealth[w] + 1)).ToString();
        }
        else
        {
            transform.GetComponent<AudioSource>().Play();
        }
    }

    public void IncreaseCount(int w)
    {

        if (Money >= increaseCountPrice * (BoughtCountCount[w] + 1))
        {
            Money -= increaseCountPrice * (BoughtCountCount[w] + 1);
            if (w == 0)
            {
                SpawnerObj.GetComponent<PlayerSpawner>().maxCount1++;
                SpawnerObj.GetComponent<PlayerSpawner>().currentCount1++;
                BoughtCountCount[w]++;
            }
            else if (w == 1)
            {
                SpawnerObj.GetComponent<PlayerSpawner>().maxCount2++;
                SpawnerObj.GetComponent<PlayerSpawner>().currentCount2++;
                BoughtCountCount[w]++;
            }
            else
            {
                SpawnerObj.GetComponent<PlayerSpawner>().maxCount3++;
                SpawnerObj.GetComponent<PlayerSpawner>().currentCount3++;
                BoughtCountCount[w]++;
            }            
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Cost : " + (increaseCountPrice * (BoughtCountCount[w] + 1)).ToString();
        }
        else
        {
            transform.GetComponent<AudioSource>().Play();
        }
    }

    public void IncreaseDamage(int w)
    {

        if (Money >= increaseDamagePrice * (BoughtCountDamage[w] + 1))
        {
            Money -= increaseDamagePrice * (BoughtCountDamage[w] + 1);
            if (w == 0)
            {
                biorem1.Damage++;
                BoughtCountDamage[w]++;
                if (GlobalOne)
                {
                    biorem1.Damage++;
                    BoughtCountDamage[w]++;
                }
            }
            else if (w == 1)
            {
                biorem2.Strength++;
                BoughtCountDamage[w]++;
                if (GlobalOne)
                {
                    biorem2.Strength++;
                    BoughtCountDamage[w]++;
                }
            }
            else
            {
                biorem3.Damage++;
                BoughtCountDamage[w]++;
                if (GlobalOne)
                {
                    biorem3.Damage++;
                    BoughtCountDamage[w]++;
                }
            }
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Cost : " + (increaseDamagePrice * (BoughtCountDamage[w] + 1)).ToString();
        }
        else
        {
            transform.GetComponent<AudioSource>().Play();
        }
    }

    public void GlobalUpgrade(int n)
    {
        switch (n)
        {
            case 0:
                //global Upgrade 1
                if (Money >= 50)
                {
                    Money -= 50;
                    GlobalOne = true;
                    biorem1.Damage *= 2;
                    biorem2.Strength *= 2;
                    biorem3.Damage *= 2;
                    EventSystem.current.currentSelectedGameObject.GetComponent<Button>().enabled = false;
                }
                else
                {
                    transform.GetComponent<AudioSource>().Play();
                }
                break;
            case 1:
                //global Upgrade 2
                if (Money >= 100)
                {
                    Money -= 100;
                    GlobalTwo = true;
                    biorem1.Health *= 2;
                    biorem1.MaxHealth *= 2;
                    biorem3.Health *= 2;
                    biorem3.MaxHealth *= 2;
                    EventSystem.current.currentSelectedGameObject.GetComponent<Button>().enabled = false;
                }
                else
                {
                    transform.GetComponent<AudioSource>().Play();
                }
                break;
            case 2:
                //global Upgrade 3
                if (Money >= 250)
                {
                    Money -= 250;
                    GlobalThree = true;
                    EventSystem.current.currentSelectedGameObject.GetComponent<Button>().enabled = false;
                }
                else
                {
                    transform.GetComponent<AudioSource>().Play();
                }
                break;
            case 3:
                //global Upgrade 4
                if (Money >= 1000)
                {
                    //win the game
                    EventSystem.current.currentSelectedGameObject.GetComponent<Button>().enabled = false;
                }
                else
                {
                    transform.GetComponent<AudioSource>().Play();
                }
                break;
        }
    }

    public void WhichUpgradeTab(int a)
    {
        UpgradeTabs[0].SetActive(false);
        UpgradeTabs[1].SetActive(false);
        UpgradeTabs[2].SetActive(false);
        UpgradeTabs[3].SetActive(false);
        UpgradeTabs[a].SetActive(true);
    }

    public void NextLevel()
    {
        GameObject[] BlastResidue = GameObject.FindGameObjectsWithTag("Explo");
        foreach (GameObject c in BlastResidue)
        {
            Destroy(c);
        }
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
                        GameObject temp2 = Instantiate(EnemyPrefabs[0]);
                        temp2.transform.GetChild(0).gameObject.GetComponent<BadChemicals>().RandomSpawn();
                        if (GlobalThree)
                        {
                            temp2.GetComponent<BadChemicals>().Heatlh /= 2f;
                            temp2.GetComponent<BadChemicals>().MaxHeatlh /= 2f;
                        }
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        GameObject temp2 = Instantiate(EnemyPrefabs[1]);
                        temp2.transform.GetChild(0).gameObject.GetComponent<BadChemicals>().RandomSpawn();
                        if (GlobalThree)
                        {
                            temp2.GetComponent<BadChemicals>().Heatlh /= 2f;
                            temp2.GetComponent<BadChemicals>().MaxHeatlh /= 2f;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < 15; i++)
                    {
                        GameObject temp2 = Instantiate(EnemyPrefabs[0]);
                        temp2.transform.GetChild(0).gameObject.GetComponent<BadChemicals>().RandomSpawn();
                        if (GlobalThree)
                        {
                            temp2.GetComponent<BadChemicals>().Heatlh /= 2f;
                            temp2.GetComponent<BadChemicals>().MaxHeatlh /= 2f;
                        }
                    }
                    EnemyPrefabs[0].transform.GetChild(0).gameObject.GetComponent<BadChemicals>().MaxHeatlh++;
                    EnemyPrefabs[0].transform.GetChild(0).gameObject.GetComponent<BadChemicals>().Heatlh++;
                    for (int i = 0; i < 10; i++)
                    {
                        GameObject temp2 = Instantiate(EnemyPrefabs[1]);
                        temp2.transform.GetChild(0).gameObject.GetComponent<BadChemicals>().RandomSpawn();
                        if (GlobalThree)
                        {
                            temp2.GetComponent<BadChemicals>().Heatlh /= 2f;
                            temp2.GetComponent<BadChemicals>().MaxHeatlh /= 2f;
                        }
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        GameObject temp2 = Instantiate(EnemyPrefabs[2]);
                        temp2.transform.GetChild(0).gameObject.GetComponent<BadChemicals>().RandomSpawn();
                        if (GlobalThree)
                        {
                            temp2.GetComponent<BadChemicals>().Heatlh /= 2f;
                            temp2.GetComponent<BadChemicals>().MaxHeatlh /= 2f;
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < 0; i++)
                    {
                        GameObject temp2 = Instantiate(EnemyPrefabs[0]);
                        temp2.transform.GetChild(0).gameObject.GetComponent<BadChemicals>().RandomSpawn();
                        if (GlobalThree)
                        {
                            temp2.GetComponent<BadChemicals>().Heatlh /= 2f;
                            temp2.GetComponent<BadChemicals>().MaxHeatlh /= 2f;
                        }
                    }
                    EnemyPrefabs[0].transform.GetChild(0).gameObject.GetComponent<BadChemicals>().MaxHeatlh++;
                    EnemyPrefabs[0].transform.GetChild(0).gameObject.GetComponent<BadChemicals>().Heatlh++;
                    for (int i = 0; i < 5; i++)
                    {
                        GameObject temp2 = Instantiate(EnemyPrefabs[1]);
                        temp2.transform.GetChild(0).gameObject.GetComponent<BadChemicals>().RandomSpawn();
                        if (GlobalThree)
                        {
                            temp2.GetComponent<BadChemicals>().Heatlh /= 2f;
                            temp2.GetComponent<BadChemicals>().MaxHeatlh /= 2f;
                        }
                    }
                    for (int i = 0; i < 15; i++)
                    {
                        GameObject temp2 = Instantiate(EnemyPrefabs[2]);
                        temp2.transform.GetChild(0).gameObject.GetComponent<BadChemicals>().RandomSpawn();
                        if (GlobalThree)
                        {
                            temp2.GetComponent<BadChemicals>().Heatlh /= 2f;
                            temp2.GetComponent<BadChemicals>().MaxHeatlh /= 2f;
                        }
                    }
                    EnemyPrefabs[2].transform.GetChild(0).gameObject.GetComponent<BadChemicals>().MaxHeatlh++;
                    EnemyPrefabs[2].transform.GetChild(0).gameObject.GetComponent<BadChemicals>().Heatlh++;
                    break;
                default:
                    if (Level != 1 && Level != 0)
                    {
                        for (int i = 0; i < Level + 10; i++)
                        {
                            GameObject temp2 = Instantiate(EnemyPrefabs[0]);
                            temp2.transform.GetChild(0).gameObject.GetComponent<BadChemicals>().RandomSpawn();
                            if (GlobalThree)
                            {
                                temp2.GetComponent<BadChemicals>().Heatlh /= 2f;
                                temp2.GetComponent<BadChemicals>().MaxHeatlh /= 2f;
                            }
                        }
                        EnemyPrefabs[0].transform.GetChild(0).gameObject.GetComponent<BadChemicals>().MaxHeatlh++;
                        EnemyPrefabs[0].transform.GetChild(0).gameObject.GetComponent<BadChemicals>().Heatlh++;
                        for (int i = 0; i < Level + 10; i++)
                        {
                            GameObject temp2 = Instantiate(EnemyPrefabs[1]);
                            temp2.transform.GetChild(0).gameObject.GetComponent<BadChemicals>().RandomSpawn();
                            if (GlobalThree)
                            {
                                temp2.GetComponent<BadChemicals>().Heatlh /= 2f;
                                temp2.GetComponent<BadChemicals>().MaxHeatlh /= 2f;
                            }
                        }
                        for (int i = 0; i < Level + 10; i++)
                        {
                            GameObject temp2 = Instantiate(EnemyPrefabs[2]);
                            temp2.transform.GetChild(0).gameObject.GetComponent<BadChemicals>().RandomSpawn();
                            if (GlobalThree)
                            {
                                temp2.GetComponent<BadChemicals>().Heatlh /= 2f;
                                temp2.GetComponent<BadChemicals>().MaxHeatlh /= 2f;
                            }
                        }
                        if (Level % 2 == 0)
                        {
                            EnemyPrefabs[2].transform.GetChild(0).gameObject.GetComponent<BadChemicals>().MaxHeatlh++;
                            EnemyPrefabs[2].transform.GetChild(0).gameObject.GetComponent<BadChemicals>().Heatlh++;
                        }
                    }
                    break;
            }
            Jukebox = GameObject.Find("Jukebox").GetComponent<JukeBox>();
            SpawnerObj.GetComponent<PlayerSpawner>().Reset();
            Time.timeScale = 1f;
            SpeedUpButtons.transform.GetChild(0).gameObject.SetActive(false);
            SpeedUpButtons.transform.GetChild(1).gameObject.SetActive(true);
            SpeedUpButtons.transform.GetChild(2).gameObject.SetActive(false);
        }
        //Jukebox.WhatShouldPlay();
    }
}
