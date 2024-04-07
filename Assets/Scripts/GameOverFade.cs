using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverFade : MonoBehaviour
{
    public IEnumerator Fade()
    {
        for (int i = 0; i < 100; i++)
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color += new Color(0,0,0,0.01f);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        yield return new WaitForSecondsRealtime(0.25f);
        for (int i = 0; i < 100; i++)
        {
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().color += new Color(0, 0, 0, 0.01f);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
}
