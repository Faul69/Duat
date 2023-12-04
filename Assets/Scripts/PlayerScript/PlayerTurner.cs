using UnityEngine;

public class PlayerTurner : MonoBehaviour
{
    [SerializeField] private Transform _model;
    public void TurnTo(Vector3 raycastHitPosition)
    {
        _model.LookAt(new Vector3(raycastHitPosition.x, transform.position.y, raycastHitPosition.z));
    }
}
