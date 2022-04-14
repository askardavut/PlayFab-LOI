using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDashboard : MonoBehaviour
{
    [SerializeField] private Text _displayName, _createdDate, _email, _playerID;
    [SerializeField] private GameObject _aSencPanel;
    [SerializeField] RawImage _avatar;
    [SerializeField] Text _resultText;
    string _tempUrl;

    private GetAccoundInfoController _getAccoundInfoController = new GetAccoundInfoController();

    private void Awake()
    {
        _getAccoundInfoController.AccountInfo();
    }

    private void Start()
    {
        StartCoroutine(AsyncDashboard());
    }


    private IEnumerator AsyncDashboard()
    {
        _aSencPanel.SetActive(true);
        _resultText.text = "Oyuncu bilgileri alýnýyor...";
        yield return new WaitUntil(() => _getAccoundInfoController.GetAccoundInfoController_Async);
        PlayersInfos();
        _resultText.text = "Avatar indiriliyor...";
        StartCoroutine(_getAccoundInfoController.DownloadAvatar(_tempUrl, _avatar));
        _resultText.text = "Giriþ yapýlýyor...";
        yield return new WaitUntil(() => _getAccoundInfoController.GetDownloadAvatarTexture_Async);

        _aSencPanel.SetActive(false);
    }

    private void PlayersInfos()
    {
        _displayName.text = _getAccoundInfoController.DisplayName;
        _email.text = _getAccoundInfoController.Email;
        _createdDate.text = _getAccoundInfoController.CreatedDate.ToShortDateString();
        _playerID.text = _getAccoundInfoController.PlayerID;
        _tempUrl = _getAccoundInfoController.AvatarURL;
    }
}