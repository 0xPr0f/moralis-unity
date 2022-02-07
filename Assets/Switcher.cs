using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switcher : MonoBehaviour
{
    public GameObject logout;
    public GameObject start;
    public void Update()
    {
        if(logout.activeSelf == true)
        {
            start.SetActive(true);
        }
        
    }
    public void Switch()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
