using UnityEngine;

public class PlayerTemple : MonoBehaviour
{
    private SoulActions _soulInBag;
    private PlayerAction _player;
    private BagViewer _bagViewer;

    public bool IsFull { get; private set; }

    private void OnEnable()
    {
        _player = GetComponent<PlayerAction>();
        _bagViewer = GetComponentInChildren<BagViewer>();
        IsFull = false;
    }

    public void AddSoul(SoulActions soul)
    {
        _soulInBag = soul;
        IsFull = true;
        _bagViewer.TakeNewSoul(_soulInBag);
        _player.PrepareToThrow(_soulInBag);
    }

    public void RemoveSoul(SoulActions soulToThrow)
    {
        _soulInBag = null;
        IsFull = false;
        _bagViewer.Clean();
        _player.PrepareToPick();
    }
}
