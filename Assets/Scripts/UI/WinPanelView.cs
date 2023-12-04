using System.Collections.Generic;
using UnityEngine;

public class WinPanelView : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enables;
    [SerializeField] private List<GameObject> _disables;

    public void ViewWinPanel()
    {
        ChangeEnable(_enables, true);
        ChangeEnable(_disables, false);
    }

    private void ChangeEnable(List<GameObject> list, bool changeTo)
    {
        foreach (GameObject gameObject in list)
        {
            gameObject.SetActive(changeTo);
        }
    }
}
