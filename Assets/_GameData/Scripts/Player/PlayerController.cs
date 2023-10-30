using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _lookRotationOffset = new Vector3(0, 0, 0);
    private void OnEnable()
    {
        EventManager.Instance.OnStairPlaced += OnStairPlacedHandler;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnStairPlaced -= OnStairPlacedHandler;
    }

    private void OnStairPlacedHandler(Vector3 stairPosition,Vector3 stairRotation)
    {
        transform.position = stairPosition;
        transform.rotation = Quaternion.LookRotation(stairRotation);
    }
}
