using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField] private OldInputSystem _inputSystem;
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        _inputSystem.MousePosChanged += ThrowRaycast;
    }

    private void OnDisable()
    {
        _inputSystem.MousePosChanged -= ThrowRaycast;
    }

    public void ThrowRaycast(Vector3 mousePos)
    {
        
        Ray ray = _camera.ScreenPointToRay(new Vector3(mousePos.x, mousePos.y, _camera.nearClipPlane));

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.TryGetComponent<PlayerTurner>(out PlayerTurner turner))
            {
                turner.TurnTo(hit.point);
            }
        }
    }
}
