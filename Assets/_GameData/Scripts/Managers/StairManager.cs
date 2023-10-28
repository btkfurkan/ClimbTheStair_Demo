using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class StairManager : MonoBehaviour
{
    public GameObject StairPrefab;
    public int StairCount;
    public float StairHeight = 0.2f;
    public float CircleRadius = 10f;

    private List<GameObject> _stairsList = new List<GameObject>();

    private void Start()
    {
        CreateObjects(StairPrefab, transform, StairCount, _stairsList);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ActivateNextAvailableStair();
        }
    }
    private void CreateObjects(GameObject prefab, Transform parent, int prefabCount, List<GameObject> prefabList)
    {
        for (int i = 0; i < prefabCount; i++)
        {
            GameObject obj = Instantiate(prefab, parent);
            obj.SetActive(false);
            prefabList.Add(obj);
        }
    }
    private void ActivateNextAvailableStair()
    {
        for (int i = 0; i < _stairsList.Count; i++)
        {
            if (!_stairsList[i].activeInHierarchy)
            {
                int stairIndex = i;

                StairPositionAndRotationUpdate(stairIndex);

                SetActiveStair(stairIndex, true);

                AnimationStair(stairIndex);
                break;
            }
        }
    }
    private void StairPositionAndRotationUpdate(int index)
    {
        float angle = CalculateStairAngle(index);

        Vector3 offset = CalculateStairOffset(angle);

        Vector3 stairPosition = CalculateStairPosition(index, offset);

        SetTransformStair(index, stairPosition, offset);
    }
    private float CalculateStairAngle(int index)
    {
        return index * (360f / _stairsList.Count);
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
    private void SetTransformStair(int index, Vector3 position, Vector3 offset)
    {
        Transform stairTransform = _stairsList[index].transform;

        stairTransform.position = position;

        stairTransform.rotation = Quaternion.LookRotation(offset);
    }
    private void AnimationStair(int index)
    {
        _stairsList[index].transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.InElastic);
    }
    private void SetActiveStair(int index, bool setActive)
    {
        _stairsList[index].SetActive(setActive);
    }
}
