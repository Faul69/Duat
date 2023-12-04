using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChaneCreator))]
public class Spawner : MonoBehaviour
{
    private const int ChanceRepeatCreate = 50;
    private const int ChanceOfRare = 10;
    private const float HideY = 30;

    [SerializeField] private Transform _path;
    [SerializeField] private List<SoulType> _soulsSimple;
    [SerializeField] private List<SoulType> _soulsRare;
    [SerializeField] private SoulBuilder _reference;
    [SerializeField] private PositionRebuilder _container;
    [SerializeField] private int _countSouls;
    [SerializeField] private Bomber _counter;

    public int CountSouls => _countSouls;

    private int _countRepeat;
    private ChaneCreator _chaneCreater;
    private SoulType _lastSoul;

    private void Awake()
    {
        _chaneCreater = GetComponent<ChaneCreator>();
        _container.Init(_chaneCreater.Delay);

        for (int i = 0; i < _countSouls; i++)
        {
            CreateSoul();
        }
    }

    private void Start()
    {
        StartCoroutine(routine: _chaneCreater.RunSoulWithDelay());
    }

    private void CreateSoul()
    {
        var newSoul = Instantiate(_reference, _container.transform);
        newSoul.transform.position = new Vector3(transform.position.x, transform.position.y - HideY, transform.position.z);
        _chaneCreater.AddSoulInPool(newSoul);
        var soulType = RandomSoul();
        newSoul.Init(soulType, _counter, _container, _path);
    }

    private SoulType RandomSoul()
    {
        if (TryChooseRareSoul(out SoulType rareSoul))
            return rareSoul;

        return ChooseSimpleSoul();
    }

    private SoulType ChooseSimpleSoul()
    {
        int numberOfSimple = Random.Range(0, _soulsSimple.Count);

        if (_lastSoul == _soulsSimple[numberOfSimple])
        {
            int chanceCountinue = ChanceRepeatCreate / _countRepeat;

            if (Random.Range(0, 100) < chanceCountinue)
            {
                _countRepeat++;
            }
            else
            {
                _countRepeat = 1;
                return ChooseRedusedSoul(numberOfSimple);
            }
        }
        else
        {
            _countRepeat = 1;
        }

        _lastSoul = _soulsSimple[numberOfSimple];
        return _soulsSimple[numberOfSimple];
    }

    private bool TryChooseRareSoul(out SoulType rareSoul)
    {
        rareSoul = null;

        if (_soulsRare.Count > 0 && Random.Range(0, 100) < ChanceOfRare)
        {
            int numberOfRare = Random.Range(0, _soulsRare.Count);
            rareSoul = _soulsRare[numberOfRare];
            return true;
        }

        return false;
    }

    private SoulType ChooseRedusedSoul(int idToReduse)
    {
        List<SoulType> soulsRedused = new List<SoulType>();

        foreach (SoulType soul in _soulsSimple)
            soulsRedused.Add(soul);

        soulsRedused.Remove(_soulsSimple[idToReduse]);
        int numberOfRedused = Random.Range(0, soulsRedused.Count);
        return soulsRedused[numberOfRedused];
    }
}
