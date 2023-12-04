using UnityEngine;

public class FrontRayPoint : MonoBehaviour
{
    private const float RayDistance = 1.5f;
    private SoulMover _mover;
    private ColorSender _colorSender;
    private bool _isSended = false;

    private void OnEnable()
    {
        _mover = gameObject.GetComponentInParent<SoulMover>();
        _colorSender = gameObject.GetComponentInParent<ColorSender>();
        _colorSender.FrontColorSender += NotifySendColor;
        _mover.BackMove += NotifyMoveBack;
        _mover.MoveOver += NotifyMoveOver;
        _mover.ResumeMove += NotifyPlayForward;
        _mover.Accelerete += NotifyAccelerate;
    }

    private void OnDisable()
    {
        _colorSender.FrontColorSender -= NotifySendColor;
        _mover.ResumeMove -= NotifyPlayForward;
        _mover.BackMove -= NotifyMoveBack;
        _mover.MoveOver -= NotifyMoveOver;
        _mover.Accelerete -= NotifyAccelerate;
    }

    public void NotifyToPrepeare()
    {
        _isSended = false;

        foreach (Vector3 direction in GetRayVectors())
        {
            if (_isSended == true)
                break;

            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, RayDistance))
            {
                if (TryGetComponentInChildren(hit, out CollisionTouch frontSoul))
                {
                    _isSended = true;
                    frontSoul.Prepeare();
                }
            }
        }
    }

    private void NotifyAccelerate(float multiplayer)
    {
        _isSended = false;

        foreach (Vector3 direction in GetRayVectors())
        {
            if (_isSended == true)
                break;

            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, RayDistance))
            {
                if (hit.collider.gameObject.TryGetComponent<SoulMover>(out SoulMover soul))
                {
                    _isSended = true;
                    soul.Accel(multiplayer);
                }
            }
        }
    }

    private void NotifySendColor(string color)
    {
        _isSended = false;

        foreach (Vector3 direction in GetRayVectors())
        {
            if (_isSended == true)
                break;

            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, RayDistance))
            {
                if (hit.collider.gameObject.TryGetComponent<ColorSender>(out ColorSender soul))
                {
                    _isSended = true;
                    soul.FrontSendColor(color);
                }

            }
        }

        if (!_isSended)
        {
            _colorSender.SendEdge();
        }
    }


    private void NotifyPlayForward()
    {
        _isSended = false;

        foreach (Vector3 direction in GetRayVectors())
        {
            if (_isSended == true)
                break;

            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, RayDistance))
            {
                if (hit.collider.gameObject.TryGetComponent<SoulMover>(out SoulMover soul))
                {
                    _isSended = true;
                    soul.PlayForward();
                }
            }
        }
    }

    private void NotifyMoveOver(float multiplayer)
    {
        _isSended = false;

        foreach (Vector3 direction in GetRayVectors())
        {
            if (_isSended == true)
                break;

            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, RayDistance))
            {
                if (hit.collider.gameObject.TryGetComponent<SoulMover>(out SoulMover soul))
                {
                    _isSended = true;
                    soul.MoveForNewSoul(multiplayer);
                }
            }
        }
    }

    private void NotifyMoveBack()
    {
        _isSended = false;

        foreach (Vector3 direction in GetRayVectors())
        {
            if (_isSended == true)
                break;
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, RayDistance))
            {
                if (hit.collider.gameObject.TryGetComponent<SoulMover>(out SoulMover soul))
                {
                    _isSended = true;
                    soul.PlayBackward();
                }
            }
        }
    }

    private Vector3[] GetRayVectors()
    {
        return new Vector3[]
        {
            transform.forward,
            transform.forward + transform.right,
            transform.forward - transform.right
        };
    }

    private bool TryGetComponentInChildren(RaycastHit hit, out CollisionTouch point)
    {
        point = hit.collider.gameObject.GetComponentInChildren<CollisionTouch>();
        return point != null;
    }
}
