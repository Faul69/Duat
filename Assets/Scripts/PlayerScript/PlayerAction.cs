using UnityEngine;

[RequireComponent(typeof(PlayerTemple))]
public class PlayerAction : MonoBehaviour
{
    [SerializeField] private float _timeScaleMultiplayer;
    [SerializeField] private float _rayDistanse;
    [SerializeField] private HandForSelect _hand;
    [SerializeField] private AudioLiblary _soundLiblary;

    private OldInputSystem _inputSystem;
    private PlayerTemple _temple;
    private SoulActions _soulToThrow;
    private bool _isPick = true;
    private bool _isFreedom = true;
    private bool _isEnd = false;

    private void Awake()
    {
        _temple = GetComponent<PlayerTemple>();
        _inputSystem = GetComponentInParent<OldInputSystem>();
    }

    private void OnEnable()
    {
        _inputSystem.LeftButtonClicked += UseSkills;
    }

    private void LateUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _rayDistanse))
        {
            if (hit.collider.TryGetComponent<SoulActions>(out SoulActions soul))
                _hand.DirectHand(soul.transform.position);
            else
                _hand.ResetPosition();
        }
    }

    private void OnDisable()
    {
        _inputSystem.LeftButtonClicked -= UseSkills;
    }

    public void UseSkills()
    {
        if (!_isFreedom || _isEnd)
            return;

        if (_soulToThrow != null)
        {
            if (Throw())
            {
                _temple.RemoveSoul(_soulToThrow);
                _soulToThrow = null;
            }
        }
        else if (!_temple.IsFull && _isPick)
            TryToPick();
    }

    public void PrepareToThrow(SoulActions soul)
    {
        _soulToThrow = soul;
        _isPick = false;
        _hand.ChangeHand(true);
    }

    public void PrepareToPick()
    {
        _isPick = true;
        _soulToThrow = null;
        _hand.ChangeHand(false);
    }

    public void ChangeFreedom(bool changeTo)
    {
        _isFreedom = changeTo;
    }

    private bool Throw()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _rayDistanse))
        {
            if (hit.collider.gameObject.TryGetComponent<SoulActions>(out SoulActions soul))
            {
                _soundLiblary.PlayThrowSoul();
                soul.MoveFaster(_timeScaleMultiplayer);
                _soulToThrow.TurnIntractable(true);
                _soulToThrow.EnterInChane(soul.GetElapsedTime(), soul.transform.position);
                return true;
            }
        }

        return false;
    }

    private void TryToPick()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _rayDistanse))
        {
            if (hit.collider.gameObject.TryGetComponent<SoulActions>(out SoulActions soul))
            {
                var soulForBag = soul.PickUp(transform.position);

                if (soulForBag == null)
                    return;

                _soundLiblary.PlayPickSound();
                _temple.AddSoul(soulForBag);
                soul.SendMoveBack(_timeScaleMultiplayer);
                soul.TurnIntractable(false);
            }
        }
    }
}
