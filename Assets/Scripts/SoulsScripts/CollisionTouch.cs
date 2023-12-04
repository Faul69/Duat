using System.Threading.Tasks;
using UnityEngine;

public class CollisionTouch : MonoBehaviour
{
    private bool _isWaiting = false;

    private ColorSender _colorSender;
    private PositionRebuilder _rebuilder;

    private void Start()
    {
        _colorSender = GetComponentInParent<ColorSender>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isWaiting)
            return;

        if (other.gameObject.TryGetComponent<SoulActions>(out SoulActions soul))
        {
            Touch(soul.GetElapsedTime());
            return;
        }

        if (other.gameObject.TryGetComponent<Spawner>(out _))
            Touch(0);
    }

    public void Prepeare()
    {
        _isWaiting = true;
    }

    public void Init(PositionRebuilder rebuilder)
    {
        _rebuilder = rebuilder;
    }

    private async void Touch(float elapsedTime)
    {
        await Task.WhenAll(_rebuilder.StartAlign(elapsedTime));
        _colorSender.StartSendColor();
        _isWaiting = false;
    }
}
