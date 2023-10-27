using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        for (int i = 0; i < StairCount; i++)
        {
            GameObject stair = Instantiate(StairPrefab, transform);
            stair.SetActive(false);
            _stairs.Add(stair);
        }

        for (int i = 0; i < ScoreHandleCount; i++)
        {
            GameObject handle = Instantiate(ScoreHandlePrefab, transform);
            handle.SetActive(false);
            _scoreHandle.Add(handle);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < _stairs.Count; i++)
            {
                if (!_stairs[i].activeInHierarchy)
                {
                    float angle = i * (360f / _stairs.Count);
                    Vector3 offset = Quaternion.Euler(0, angle, 0) * Vector3.forward;


                    Vector3 stairPosition = transform.position + offset * CircleRadius;
                    stairPosition.y = i * StairHight;

                    _stairs[i].transform.position = stairPosition;
                    _stairs[i].transform.rotation = Quaternion.LookRotation(offset);
                    _stairs[i].SetActive(true);
                    _stairs[i].transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.InElastic).OnComplete(() => { _stairs[i].GetComponent<BoxCollider>().enabled = true; });
                    break;
                }
            }

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
}
