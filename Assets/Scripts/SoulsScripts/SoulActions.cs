using System.Threading.Tasks;
using UnityEngine;

public class SoulActions : MonoBehaviour
{
    [SerializeField] private float _timeBodyAnimation;

    private SoulMover _mover;
    private SoulVisualiser _body;
    private SoulBuilder _builder;
    private ColorSender _collapce;
    private FrontRayPoint _frontPoint;
    private BackRayPoint _backPoint;
    private CollisionTouch _touch;
    private bool _isPickble;

    public void Init()
    {
        _mover = GetComponent<SoulMover>();
        _body = GetComponent<SoulVisualiser>();
        _builder = GetComponent<SoulBuilder>();
        _isPickble = GetComponent<SoulBuilder>().IsPickeble;
        _collapce = GetComponent<ColorSender>();
        _frontPoint = GetComponentInChildren<FrontRayPoint>();
        _backPoint = GetComponentInChildren<BackRayPoint>();
        _touch = GetComponentInChildren<CollisionTouch>();
    }

    #region:MovingAction

    public void MoveFaster(float timeScaleMultiplayer)
    {
        _mover.MoveForNewSoul(timeScaleMultiplayer);
    }

    public float GetElapsedTime()
    {
        return _mover.GetElapsed();
    }

    public async void EnterInChane(float needTime, Vector3 needPosition)
    {
        _body.Appear(_timeBodyAnimation);
        await _mover.MoveToChane(needPosition);
        _mover.SetTweenTime(needTime);
        _mover.PlayForward();
        _collapce.StartSendColor();
    }

    public SoulActions PickUp(Vector3 playerPosition)
    {
        if (_isPickble)
        {
            _mover.MoveToPlayer(playerPosition);
            return this;
        }

        return null;
    }

    public void SendMoveBack(float multiplayer)
    {
        if (_backPoint.ChekSoulInBack())
        {
            _mover.PlayBackward(false);
            _mover.Accel(multiplayer);
            _frontPoint.NotifyToPrepeare();
        }
    }

    public void MoveBack(float multiplayer)
    {
        _mover.PlayBackward(true);
        _touch.Prepeare();
        _mover.Accel(multiplayer);
    }

    #endregion

    public async void Boom()
    {
        GetComponent<SphereCollider>().enabled = false;
        _body.Disappear(_timeBodyAnimation);
        await Task.Delay((int)_timeBodyAnimation * 1000);
        _mover.Pause();
        GetComponent<SphereCollider>().enabled = true;
        _mover.transform.position = Vector3.zero;
    }

    public void TurnIntractable(bool isIntrbl)
    {
        if (!_isPickble)
            return;

        if (isIntrbl)
            _body.Appear(_timeBodyAnimation);
        else
            _body.Disappear(_timeBodyAnimation);
    }

    public void StartMove()
    {
        _mover.StartAnimation();
        _body.Appear(_timeBodyAnimation);
    }
}
