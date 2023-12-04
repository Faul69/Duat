using UnityEngine;
using UnityEngine.UI;

public class TutorEnabler : MonoBehaviour
{
    private Toggle _checkBox;

    private void OnEnable()
    {
        _checkBox = GetComponent<Toggle>();

#if UNITY_WEBGL && !UNITY_EDITOR
        _checkBox.isOn = Agava.YandexGames.Progress.Instance.Info.IsTutorial;
#endif

#if UNITY_EDITOR && !UNITY_WEBGL
        _checkBox.isOn = true;
#endif

        _checkBox.onValueChanged.AddListener(EnableTraining);
    }

    private void OnDisable()
    {
        _checkBox.onValueChanged.RemoveListener(EnableTraining);
    }

    private void EnableTraining(bool value)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.Progress.Instance.Info.IsTutorial = value;
#endif
    }
}
