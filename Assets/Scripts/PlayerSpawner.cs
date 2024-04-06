using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private int currentCount1;
    private int maxCount1;
    private int currentCount2;
    private int maxCount2;
    private GameObject selected;
    // Start is called before the first frame update
    void Start()
    {
        currentCount1 = maxCount1;
        currentCount2 = maxCount2;
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selected != null)
        {
            switch (selected.name)
            {
                case ("Ally1"):
                    if (currentCount1 > 0)
                    {
                        currentCount1--;                
                    }
                    else
                    {
                        //play error sound effect
                    }
                    break;
                case ("Ally2"):
                    if (currentCount2 > 0)
                    {
                        currentCount2--;
                    }
                    else
                    {
                        //play error sound effect
                    }
                    break;
            }
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
                    //play error sound effect
                }
                break;
            case ("Ally2"):
                if (currentCount2 > 0)
                {
                    selected = ally;
                }
                else
                {
                    //play error sound effect
                }
                break;
        }
    }
}
