using UnityEngine;

public class Worm : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private WormHeathView _healthViewer;

    private WinGame _win;
    private int _currentHealth;

    public int CurrentHealth => _currentHealth;

    private void OnEnable()
    {
        _win = GetComponent<WinGame>();
        _currentHealth = _maxHealth;
    }

    private void Start()
    {
        _healthViewer.SetStartValues(_currentHealth, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _win.EndWin();
            StartCoroutine(_healthViewer.SetValue(0, _maxHealth));
            return;
        }

        StartCoroutine(_healthViewer.SetValue(_currentHealth, _maxHealth));
    }
}
