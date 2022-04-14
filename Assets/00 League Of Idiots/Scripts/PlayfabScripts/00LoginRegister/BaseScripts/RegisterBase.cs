using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class RegisterBase
{
    public bool RegisterBase_Async { get; set; }

    public void RegisterEmail(string _username, string _email, string _password)
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest()
        {
            Username = _username,
            Email = _email,
            Password = _password,
            DisplayName = _username
        },

            Result =>
            {
                RegisterBase_Async = true;
                Debug.Log("Kayýt Tamamlandý");
            },
            Error =>
            {
                RegisterBase_Async = false;
                Debug.Log("Kayýt Hatasý !!!!!!!!!!");
            });
    }
}