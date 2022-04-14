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
                Debug.Log("Giriþ Yapýldý");
            },
            Error =>
            {
                LoginBase_Async = false;
                Debug.Log("Giriþ Hatasý !!!!!!!!!!");
            });



    }

    public void LoginGuest()
    {
        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest()
        {
            CreateAccount = true, CustomId ="Misafir Girisi", 
        },

            Success =>
            {
                Debug.Log("Misafir Giriþi Baþarýlý");
            },
            Error =>
            {
                Debug.Log("Misafir Giriþ Yapamadý");
            });
    }


}