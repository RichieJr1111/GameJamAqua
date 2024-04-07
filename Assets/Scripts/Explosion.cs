using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GoodGuy")
        {
            other.GetComponent<PlayerAlly>().Health -= 1;
            if (other.GetComponent<PlayerAlly>().Health < 0)
            {
                other.GetComponent<PlayerAlly>().Health = 0;
            }
            //other.GetComponent<PlayerAlly>().Speed = 0;
        }
    }
}
