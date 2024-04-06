using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodExploScript : MonoBehaviour
{
    public float Strength = 3f;

    private void OnEnable()
    {
        StartCoroutine(WhenGo());
    }

    private IEnumerator WhenGo()
    {
        yield return new WaitForSeconds(0.85f);
        transform.GetComponent<Collider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<BadChemicals>().Heatlh -= Strength;
            //other.GetComponent<PlayerAlly>().Speed = 0;
        }
    }
}
