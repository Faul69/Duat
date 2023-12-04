using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class TowerChargeView : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Slider _slider;
    private Text _sliderText;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
        _sliderText = GetComponentInChildren<Text>();
    }

    public void SetValue(int currentComboCount, int maxCombo)
    {
        var endValue = (float)currentComboCount / maxCombo;

        if (endValue == 0)
            _slider.value = 0;
        else
            StartCoroutine(SmoothChangeValue(endValue));

        _sliderText.text = $"{currentComboCount}/{maxCombo}";
    }

    public void SetStartValues(int currentComboCount, int maxCombo)
    {
        _slider.value = (float)currentComboCount / maxCombo;
        _sliderText.text = $"{currentComboCount}/{maxCombo}";
    }

    private IEnumerator SmoothChangeValue(float endValue)
    {
        while (_slider.value < endValue)
        {
            yield return null;
            _slider.value = Mathf.MoveTowards(_slider.value, endValue, Time.deltaTime * _speed);
        }
    }
}
