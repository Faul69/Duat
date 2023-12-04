using UnityEngine;

[RequireComponent(typeof(CollisionTouch))]
public class BackRayPoint : MonoBehaviour
{
    private const float RayDistance = 1.4f;

    private ColorSender _colorSender;
    private bool _isSended = false;


    private void OnEnable()
    {
        _colorSender = gameObject.GetComponentInParent<ColorSender>();
        _colorSender.BackColorSender += TrySendColor;
    }

    private void OnDisable()
    {
        _colorSender.BackColorSender -= TrySendColor;

    }

    public bool ChekSoulInBack()
    {
        foreach (Vector3 direction in GetRayVectors())
        {
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, RayDistance))
            {
                if (hit.collider.gameObject.TryGetComponent<SoulActions>(out _))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void TrySendColor(string color)
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
                    soul.BackSendColor(color);
                }
            }
        }

        if (!_isSended)
        {
            _colorSender.SendEdge();
        }
    }

    private Vector3[] GetRayVectors()
    {
        return new Vector3[]
        {
            -transform.forward,
            -transform.forward + transform.right,
            -transform.forward - transform.right
        };
    }
}
