using UnityEngine;
using DG.Tweening;

public class StairManager : MonoBehaviour
{
    [Header("Basamak Ayarları")]
    [SerializeField] private PoolManager poolManager;

    public float circleRadius;
    public float stairHeight;

    private int _numberOfStairs;
    private int currentStairIndex = 0;
    private int _objectStair = 0;
    private void Start()
    {
        _numberOfStairs = poolManager.pools[_objectStair].poolSize;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateStair(currentStairIndex);

            currentStairIndex++;
        }
    }
    private void CreateStair(int index)
    {
        float angle = CalculateStairAngle(index);

        Vector3 offset = CalculateStairOffset(angle);

        Vector3 stairPosition = CalculateStairPosition(index, offset);

        GameObject stair = poolManager.GetPooledObject(_objectStair);

        if (stair != null)
        {
            SetTransformStair(stair, stairPosition, offset);
        }
    }
    private float CalculateStairAngle(int index)
    {
        return index * (360f / _numberOfStairs);
    }
    private Vector3 CalculateStairOffset(float angle)
    {
        return Quaternion.Euler(0, angle, 0) * Vector3.forward;
    }
    private Vector3 CalculateStairPosition(int index, Vector3 offset)
    {
        Vector3 stairPosition = transform.position + offset * circleRadius;

        stairPosition.y = index * stairHeight;

        return stairPosition;
    }
    private void SetTransformStair(GameObject stair, Vector3 position, Vector3 offset)
    {
        Transform stairTransform = stair.transform;

        stairTransform.position = position;

        stairTransform.rotation = Quaternion.LookRotation(offset);
    }
}
