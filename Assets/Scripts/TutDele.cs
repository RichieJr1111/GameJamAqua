using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutDele : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Fade());
            Destroy(gameObject, 0.5f);
        }
    }

    private IEnumerator Fade()
    {
        for (int i = 0; i < 50; i++)
        {
            transform.GetComponent<TextMeshProUGUI>().color -= new Color(0, 0, 0, 0.02f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
