using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increasestat : MonoBehaviour
{
    public GameObject bioremob;
    public PlayerAlly biorem;
    public static int Level = 1;
    public GameObject[] EnemyPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        biorem = bioremob.GetComponent<PlayerAlly>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
        {
            Time.timeScale = 0;
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0, 22, -10), 0.001f);
        }
        else
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0, 0, -10), 0.001f);
        }
    }

    public void IncreaseHealth()
    {
        biorem.Health++;
    }

    public void NextLevel()
    {
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
