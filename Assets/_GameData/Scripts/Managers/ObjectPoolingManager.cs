using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class ObjectPoolingManager : MonoBehaviour
{
    public GameObject ScoreHandlePrefab;
    public GameObject StairPrefab;
    public int StairCount;
    public int ScoreHandleCount;
    public float ScoreHandleHight = 0.2f;
    public float StairHight = 0.2f;
    public float CircleRadius = 10f;

    private List<GameObject> _scoreHandle = new List<GameObject>();
    private List<GameObject> _stairs = new List<GameObject>();

    private void Start()
    {
        CreateObjects(ScoreHandlePrefab, transform, ScoreHandleCount, _scoreHandle);
        CreateObjects(StairPrefab, transform, StairCount, _stairs);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ActivateNextAvailableStair();

            for (int h = 0; h < _scoreHandle.Count; h++)
            {
                if (!_scoreHandle[h].activeInHierarchy)
                {
                    Vector3 handlePosition = transform.position + Vector3.up * (h * ScoreHandleHight);
                    _scoreHandle[h].transform.position = handlePosition;
                    _scoreHandle[h].SetActive(true);
                    _scoreHandle[h].transform.DOScale(new Vector3(1, 0.25f, 1), 0.3f).SetEase(Ease.InElastic).OnComplete(() => { _scoreHandle[h].GetComponent<BoxCollider>().enabled = true; });
                    break;
                }
            }
        }
    }
    private void CreateObjects(GameObject prefab, Transform transform, int prefabCount, List<GameObject> prefabList)
    {
        for (int i = 0; i < prefabCount; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            prefabList.Add(obj);
        }
    }
    private void ActivateNextAvailableStair()
    {
        for (int i = 0; i < _stairs.Count; i++)
        {
            if (!_stairs[i].activeInHierarchy)
            {
                StairPositionAndRotationUpdate(i);
                StairSetActive(i, true);
                StairAnimation(i);
                break;
            }
        }
    }
    private void StairPositionAndRotationUpdate(int index)
    {
        float angle = StairCalculateAngle(index);
        Vector3 offset = StairCalculateOffset(angle);
        Vector3 stairPosition = StairCalculatePosition(index, offset);
        StairSetTransform(index, stairPosition, offset);
    }
    private float StairCalculateAngle(int index)
    {
        return index * (360f / _stairs.Count);
    }
    private Vector3 StairCalculateOffset(float angle)
    {
        return Quaternion.Euler(0, angle, 0) * Vector3.forward;
    }
    private Vector3 StairCalculatePosition(int index, Vector3 offset)
    {
        Vector3 stairPosition = transform.position + offset * CircleRadius;
        stairPosition.y = index * StairHight;
        return stairPosition;
    }
    private void StairSetTransform(int index, Vector3 position, Vector3 offset)
    {
        Transform stairTransform = _stairs[index].transform;
        stairTransform.position = position;
        stairTransform.rotation = Quaternion.LookRotation(offset);
    }
    private void StairAnimation(int index)
    {
        _stairs[index].transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.InElastic).OnComplete(() => { _stairs[index].GetComponent<BoxCollider>().enabled = true; });
    }
    private void StairSetActive(int index, bool setActive)
    {
        _stairs[index].SetActive(setActive);
    }
}
