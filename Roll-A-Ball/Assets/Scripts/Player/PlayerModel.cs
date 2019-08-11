using System;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public const float Speed = 10.0f;

    public Rigidbody Rigidbody { get; private set; }

    private int _collectibleCount;
    public event Action<int> OnCollectibleCountChanged;
    public int CollectibleCount
    {
        get => _collectibleCount;
        set
        {
            _collectibleCount = value;
            OnCollectibleCountChanged?.Invoke(_collectibleCount);
        }
    }
    
    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        CollectibleCount = 0;
    }
}