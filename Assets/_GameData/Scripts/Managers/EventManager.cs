using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public event Action<Vector3, Vector3> OnStairPlaced;
    public void RaiseStairPlaced(Vector3 stairPosition, Vector3 stairRotation) => OnStairPlaced?.Invoke(stairPosition, stairRotation);

    public event Action OnOpenChestAnimation;
    public void RaiseOpenChest() => OnOpenChestAnimation?.Invoke();

    public event Action OnGameStarted;
    public void RaiseGameStarted() => OnGameStarted?.Invoke();
}
