using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChanger : MonoBehaviour
{
    private const string RuCode = "ru";
    private const string EngCode = "en";
    private const string TurCode = "tr";

    private List<string> _languages = new() { RuCode, EngCode, TurCode };

    public void ChooseLanguage(int index)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.Progress.Instance.Info.LanguageCode = _languages[index];
        Agava.YandexGames.Progress.Instance.Save();
#endif
    }
}
