using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetAccoundInfoController
{
    public string DisplayName { get; set; }
    public DateTime CreatedDate { get; set; }
    public string PlayerID { get; set; }
    public string Email { get; set; }
    public string AvatarURL { get; set; }
    public bool IsBan { get; set; }

    public bool GetAccoundInfoController_Async { get; set; }
    public bool GetDownloadAvatarTexture_Async { get; set; }


    public void AccountInfo()
    {
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(),
            Result =>
            {
                DisplayName = Result.AccountInfo.TitleInfo.DisplayName;
                CreatedDate = Result.AccountInfo.TitleInfo.Created.Date;
                PlayerID = Result.AccountInfo.PlayFabId;
                Email = Result.AccountInfo.PrivateInfo.Email;
                AvatarURL = Result.AccountInfo.TitleInfo.AvatarUrl;
                IsBan = Result.AccountInfo.TitleInfo.isBanned.Value;


                GetAccoundInfoController_Async = true;
            },
            Error =>
            {
                GetAccoundInfoController_Async = false;
            });
    }

    public IEnumerator DownloadAvatar(string _avatarUrl, RawImage _avatar)
    {
        UnityWebRequest _request = UnityWebRequestTexture.GetTexture(_avatarUrl);
        yield return _request.SendWebRequest();

        if (_request.isNetworkError || _request.isHttpError)
        {
            Debug.LogError("Görsel indirilirken, baðlantý problemi yaþandý. ==>> " + _request.error);
        }
        else
        {
            _avatar.texture = ((DownloadHandlerTexture)_request.downloadHandler).texture;
            GetDownloadAvatarTexture_Async = true;
        }
    }
}
