using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalerUI : MonoBehaviour
{
    private const float ScalePC = 1.4f;

    [SerializeField] private List<GameObject> _gameInterface;

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (!Agava.WebUtility.Device.IsMobile)
        {
            foreach (GameObject ui in _gameInterface)
            {
                ui.transform.localScale = new Vector3(ScalePC, ScalePC, ScalePC);
            }
        }
#endif
    }
}
