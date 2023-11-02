using UnityEngine;

public class StairManager : MonoBehaviour
{
    [Header("Stair Settings")]
    [SerializeField] private PoolManager poolManager;

    public float CircleRadius;
    public float StairHeight;

    private bool _isGameActive;
    private int _numberOfStairs;
    private int currentStairIndex = 0;
    private int _objectStair = 0;
    private Transform _currentStairTransform;
    private void Start()
    {
        _numberOfStairs = poolManager.pools[_objectStair].poolSize;
    }
    private void Update()
    {
        _isGameActive = MenuController.Instance.GetGameState();
        if (!_isGameActive) return;

        if (Input.GetMouseButtonDown(0) && _isGameActive)
        {
            CreateStair(currentStairIndex);
            currentStairIndex++;
        }
    }
    private void CreateStair(int index)
    {
        #region Set Transform
        float angle = CalculateStairAngle(index);

        Vector3 offset = CalculateStairOffset(angle);

        Vector3 stairPosition = CalculateStairPosition(index, offset);

        #endregion

        GameObject stair = poolManager.GetPooledObject(_objectStair);

        if (stair != null)
        {
            SetTransformStair(stair, stairPosition, offset);

            EventManager.Instance.RaiseStairPlaced(stairPosition, _currentStairTransform.right);
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
        Vector3 stairPosition = transform.position + offset * CircleRadius;

        stairPosition.y = index * StairHeight;

        return stairPosition;
    }
    private void SetTransformStair(GameObject stair, Vector3 position, Vector3 offset)
    {
        _currentStairTransform = stair.transform;

        _currentStairTransform.position = position;

        _currentStairTransform.rotation = Quaternion.LookRotation(offset);
    }
}
