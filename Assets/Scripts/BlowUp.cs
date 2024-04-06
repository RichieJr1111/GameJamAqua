using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUp : MonoBehaviour
{
    public GameObject Explosion;
    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<BadChemicals>().Heatlh <= 0)
        {
            Destroy(Instantiate(Explosion, transform.position, transform.rotation), 0.5f);
            transform.GetComponent<BlowUp>().enabled = false;
        }
    }
}
