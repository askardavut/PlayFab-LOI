using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichDisplaynamePanel : MonoBehaviour
{
    [SerializeField] GameObject _displaynamePanel;
    
    public void SwitchPanel()
    {
        switch (_displaynamePanel.activeInHierarchy)
        {
            case true:
                _displaynamePanel.SetActive(false);
                break;

            default:
                _displaynamePanel.SetActive(true);
                break;
        }
    }
}
