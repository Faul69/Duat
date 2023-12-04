using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(Button))]
public class RestartLvL : MonoBehaviour
{
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
