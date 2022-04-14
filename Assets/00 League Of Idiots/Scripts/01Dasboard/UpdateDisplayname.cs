using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpdateDisplayname : MonoBehaviour
{
    [SerializeField] InputField _displayname;
    public void UpdateDisplaynameOnClick( )
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest()
        {
             DisplayName = _displayname.text
        },
        Success =>
        {
            SceneManager.LoadScene(1);
        },

        Error =>
        {
            Debug.Log("DisplayNameGüncellenemedi");
        });
    }

}
