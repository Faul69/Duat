using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    private const int FirstCombo = 1;
    private const int SecondCombo = 2;
    private const int ThirdCombo = 3;
    private const float ComboStartSpeedMultiplayer = 4f;

    [SerializeField] private TowerCharge _score;
    [SerializeField] private AudioLiblary _soundLiblary;

    private List<SoulActions> _souls;
    private SoulActions _frontEdge;
    private SoulActions _backEdge;
   private PlayerAction _player;
    private int _edgeCount = 0;
    private int _comboCounter = 0;

    private void OnEnable()
    {
        _souls = new List<SoulActions>();
       _player = GetComponent<PlayerAction>();
    }

    public void AddNew(ColorSender soul)
    {
        _souls.Add(soul.gameObject.GetComponent<SoulActions>());
    }

    public void CountEdge()
    {
        ++_edgeCount;

        if (_edgeCount == 2)
        {
            if (_souls.Count >= 3)
            {
                _player.ChangeFreedom(false);
                BoomSouls();
                TryFrontGoBack();
            }
            else
            {
               _player.ChangeFreedom(true);
                _comboCounter = 0;
                _score.EndCombo();
            }

            ResetData();
        }
    }

    public void SetFrontEdge(ColorSender soul)
    {
        _frontEdge = soul.gameObject.GetComponent<SoulActions>();
    }

    public void SetBackEdge(ColorSender soul)
    {
        _backEdge = soul.gameObject.GetComponent<SoulActions>();
    }

    private void BoomSouls()
    {
        _comboCounter++;

        PlayBoomSound(_comboCounter);

        foreach (SoulActions soul in _souls)
        {
            soul.Boom();
        }

        _score.ScoringPoints(_souls.Count, _comboCounter);
    }

    private void TryFrontGoBack()
    {
        if (_frontEdge != null && _backEdge != null)
        {
            float endMultiplayer = ComboStartSpeedMultiplayer + _comboCounter;
            _frontEdge.MoveBack(endMultiplayer);
        }
        else
        {
           _player.ChangeFreedom(true);
            _comboCounter = 0;
            _score.EndCombo();
        }
    }

    private void ResetData()
    {
        _souls.Clear();
        _frontEdge = null;
        _edgeCount = 0;
    }

    private void PlayBoomSound(int comboCount)
    {
        switch (comboCount)
        {
            case FirstCombo:
                _soundLiblary.PlayLowCombo();
                break;
            case SecondCombo:
                _soundLiblary.PlayComboMid();
                break;
            case ThirdCombo:
                _soundLiblary.PlayComboStrong();
                break;
            default:
                _soundLiblary.PlayComboStrong();
                break;
        }
    }
}
