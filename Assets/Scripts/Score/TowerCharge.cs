using UnityEngine;

public class TowerCharge : MonoBehaviour
{
    private const int PointsPerSoul = 100;
    private const int MaxCharge = 10;

    [SerializeField] private TowerChargeView _chargeViewer;
    [SerializeField] private ScoreText _text;
    [SerializeField] private Worm _worm;

    private int _scoreForShoot = 0;
    private int _currentCharge = 0;
    private int _actualComboScore = 0;
    private int _actualBombedSouls = 0;
    private int _actualComboCount = 0;

    private void Start()
    {
        _chargeViewer.SetStartValues(_actualComboCount, MaxCharge);
    }

    public void ScoringPoints(int countSouls, int countCombo)
    {
        _actualBombedSouls += countSouls;
        _actualComboScore = _actualBombedSouls * PointsPerSoul * countCombo;
        _actualComboCount = countCombo;
        SetValues(countCombo);
    }

    public void EndCombo()
    {
        _scoreForShoot += _actualComboScore;
        _currentCharge += _actualComboCount;
        _actualComboScore = 0;
        _actualBombedSouls = 0;
        _actualComboCount = 0;

        SetValues(_actualComboCount);
        SendActualScore();
    }

    private void SendActualScore()
    {
        if (_currentCharge >= MaxCharge)
        {
            _worm.TakeDamage(_scoreForShoot);
            _scoreForShoot = 0;
            _currentCharge = 0;
        }

        _chargeViewer.SetValue(_currentCharge, MaxCharge);
    }

    private void SetValues(int countCombo)
    {
        _text.SetNewValue(_scoreForShoot, _actualComboScore, countCombo);
        _chargeViewer.SetValue(_currentCharge, MaxCharge);
    }
}
