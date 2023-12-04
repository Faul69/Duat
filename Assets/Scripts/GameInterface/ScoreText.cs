using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Threading.Tasks;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private Text _comboCount;
    [SerializeField] private Text _currentComboScore;

    private Text _score;

    private void OnEnable()
    {
        _score = GetComponent<Text>();
        _score.text = "0";
        _comboCount.text = "0";
        _currentComboScore.text = "0";
    }

    public void SetNewValue(int scoreForShoot, int currentcomboScore, int comboCount)
    {
        _score.DOText(scoreForShoot.ToString(), 1, true, ScrambleMode.Numerals);
        _currentComboScore.DOText(currentcomboScore.ToString(), 1, true, ScrambleMode.Numerals);
        _comboCount.text = comboCount.ToString();
    }
}
