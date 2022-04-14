using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    #region Preference Class

    private RegisterBase _registerBase = new RegisterBase();
    private GetDefaultAvatarImage _getDefaultAvatarImage = new GetDefaultAvatarImage();
    private InputController _inputController = new InputController();

    #endregion Preference Class

    [Header("Default Avatar URL")]
    [SerializeField] private string _avatarUrl;

    [SerializeField] private InputField _username, _email, _password, _repeatPassword;
    [SerializeField] private GameObject _aSencPanel;
    [SerializeField] private Text _asencText;
    [SerializeField] private Button _registerButton;

    private bool _isUpdateAvatar;

    public void RegisterOnClick()
    {
        StartCoroutine(ASencRegister());
    }

    public void RegisterInputController()
    {
        _inputController.RegisterInputControl(_email, _password, _repeatPassword, _username, _registerButton);
    }

    private IEnumerator ASencRegister()
    {
        _aSencPanel.SetActive(true);
        _registerBase.RegisterEmail(_username.text, _email.text, _password.text);
        yield return new WaitUntil(() => _registerBase.RegisterBase_Async);
        _asencText.text = "Default Avatar Yükleniyor";
        _getDefaultAvatarImage.GetDefaultAvatar( _avatarUrl);
        yield return new WaitUntil(() => _getDefaultAvatarImage._isAvatarUploaded);
        SceneManager.LoadScene(1);
    }
}