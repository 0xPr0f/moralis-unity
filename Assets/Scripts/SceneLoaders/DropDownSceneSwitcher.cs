using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class DropDownSceneSwitcher : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    void Start()
    {
        dropdown.onValueChanged.AddListener(delegate
        {
            SwitchScene(dropdown.value);
        });

    }
    public void changeToWeb3Api()
    {
        SceneManager.LoadScene("Web3ApiMethods");
    }
    public void changeToObjectandQueries()
    {
        SceneManager.LoadScene("ObjectandQueries");
    }
    public void changeToTransactions()
    {
        SceneManager.LoadScene("Transactions");
    }

    private void SwitchScene(int value)
    {
        switch (value)
        {
            case 0:
                changeToWeb3Api();
                break;
            case 1:
                changeToObjectandQueries();
                break;
            case 2:
                changeToTransactions();
                break;
        }

    }
}
