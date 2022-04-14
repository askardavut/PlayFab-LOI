using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaneRegisterOrLoginPanel : MonoBehaviour
{
    [SerializeField] GameObject _registerPanel, _loginPanel;

    public void ChangePanel()
    {
        switch (_registerPanel.activeInHierarchy)
        {
            case true:
                _loginPanel.SetActive(true);
                _registerPanel.SetActive(false);
                break;
            case false:
                _registerPanel.SetActive(true);
                _loginPanel.SetActive(false);
                break;

        }
    }
}
