using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class GetDefaultAvatarImage
{
    public bool _isAvatarUploaded { get; set; }
    public void GetDefaultAvatar(string _currentAvatarUrl)
    {
        _currentAvatarUrl = _currentAvatarUrl.ToString();

        PlayFabClientAPI.UpdateAvatarUrl(new UpdateAvatarUrlRequest()
        {

            ImageUrl = _currentAvatarUrl
        },
            Result =>
            {
                Debug.Log("Görsel Yüklendi");
                _isAvatarUploaded = true;

            },
            Error =>
            {
                Debug.Log("Görsel Yüklenmedi");
            });
    }
}
