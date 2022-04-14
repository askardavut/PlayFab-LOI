using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class LoginBase
{
    public bool LoginBase_Async { get; set; }

    public void LoginUsername(string _username, string _password)
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest()
        {
            Username = _username,
            Password = _password
        },

            Result =>
            {
                LoginBase_Async = true;
                Debug.Log("Giri� Yap�ld�");
            },
            Error =>
            {
                LoginBase_Async = false;
                Debug.Log("Giri� Hatas� !!!!!!!!!!");
            });
    }
}