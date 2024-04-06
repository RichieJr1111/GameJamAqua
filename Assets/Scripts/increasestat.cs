using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increasestat : MonoBehaviour
{
    public GameObject bioremob;
    public PlayerAlly biorem;
    // Start is called before the first frame update
    void Start()
    {
        biorem = bioremob.GetComponent<PlayerAlly>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseHealth()
    {
        biorem.Health++;
    }
}
