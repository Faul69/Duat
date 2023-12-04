using UnityEngine;

[RequireComponent(typeof (Camera))]
public class FoVChanger : MonoBehaviour
{
    private const int MobileFoV = 36;
    private const int DesktopFoV = 27;

    private void OnEnable()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Change(Agava.WebUtility.Device.IsMobile);
#endif
    }

    private void Change(bool isMobile)
    {
        if (isMobile)
            GetComponent<Camera>().fieldOfView = MobileFoV;
        else
            GetComponent<Camera>().fieldOfView = DesktopFoV;
    }
}
