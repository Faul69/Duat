using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoMainMenu : MonoBehaviour
{
    private const string MainMenu = "MainMenu";

    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Load);
    }


    private void OnDisable()
    {
        _button.onClick.RemoveListener(Load);
    }

    private void Load()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
