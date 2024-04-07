using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public GameObject Instructiond;
    public GameObject FadeObj;
    public void StartGame()
    {
        StartCoroutine(Transition());
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Instructiond.activeSelf)
        {
            Instructiond.SetActive(false);
        }
    }

    private IEnumerator Transition()
    {
        for (int i = 0; i < 100; i++)
        {
            FadeObj.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene("SampleScene");
    }

    public void Instruction()
    {
        //how to play
        Instructiond.SetActive(true);
    }
}
