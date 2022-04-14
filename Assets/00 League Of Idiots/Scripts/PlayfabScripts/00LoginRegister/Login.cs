using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    #region Preference Class

    private LoginBase _loginBase = new LoginBase();
    private InputController _inputController = new InputController();

    #endregion Preference Class

    [SerializeField] private InputField _username, _password;
    [SerializeField] private GameObject _aSencPanel;
    [SerializeField] private Text _asencText;
    [SerializeField] private Button _loginButton;
    
    public void LoginOnClick()
    {
        StartCoroutine(ASencLogin());
    }

    public void LoginInputController()
    {
        _inputController.LoginInputControl(_username, _password, _loginButton);
    }

    private IEnumerator ASencLogin()
    {
        _aSencPanel.SetActive(true);
        _asencText.text = "Giriþ Yapýlýyor";
        _loginBase.LoginUsername(_username.text, _password.text);
        yield return new WaitUntil(() => _loginBase.LoginBase_Async);
        SceneManager.LoadScene(1);
    }
}