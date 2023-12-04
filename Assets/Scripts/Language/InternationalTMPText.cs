using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InternationalTMPText : MonoBehaviour
{
    private const string RuCode = "ru";
    private const string EngCode = "en";
    private const string TurCode = "tr";

    [SerializeField] private string _en;
    [SerializeField] private string _ru;
    [SerializeField] private string _tur;
    [SerializeField] private TextMeshProUGUI _tmp;

    private string _currentLanguageCode;

    private void OnEnable()
    {
        TranslateString();
    }

    public void TranslateString()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        _currentLanguageCode = Agava.YandexGames.Progress.Instance.Info.LanguageCode;
#endif
        _tmp.text = _currentLanguageCode switch
        {
            RuCode => _ru,
            EngCode => _en,
            TurCode => _tur,
            _ => _ru,
        };
    }
}
