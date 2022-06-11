using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject[] Object;

    private void Start()
    {

        foreach (Object objects in Object)
        {

            DontDestroyOnLoad(objects);

        }

    }
}
