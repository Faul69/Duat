using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WormHeathView : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Slider _healthSlider;
    private Text _healthText;

    private void OnEnable()
    {
        _healthSlider = GetComponent<Slider>();
        _healthText = GetComponentInChildren<Text>();
    }

    public IEnumerator SetValue(int currentHealth, int maxHealth)
    {
        var sliderEndValue = (float) currentHealth / maxHealth;
        _healthText.text = $"{currentHealth}/{maxHealth}";

        while (_healthSlider.value != sliderEndValue)
        {
            yield return null;
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, sliderEndValue, Time.deltaTime * _speed);
        }
    }

    public void SetStartValues(int currentHealth, int maxHealth)
    {
        _healthSlider.value = (float)currentHealth / maxHealth;
        _healthText.text = $"{currentHealth}/{maxHealth}";
    }
}
