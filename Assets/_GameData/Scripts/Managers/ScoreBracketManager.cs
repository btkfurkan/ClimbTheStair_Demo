using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBracketManager : MonoBehaviour
{
    public GameObject ScoreBracketPrefab;
    public int ScoreBracketCount;
    public float ScoreBracketHeight = 0.2f;

    private List<GameObject> _scoreBracketList = new List<GameObject>();

    private void Start()
    {

        CreateObjects(ScoreBracketPrefab, transform, ScoreBracketCount, _scoreBracketList);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ActivateNextAvailableScoreBracket();
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
    private void ActivateNextAvailableScoreBracket()
    {
        for (int h = 0; h < _scoreBracketList.Count; h++)
        {
            if (!_scoreBracketList[h].activeInHierarchy)
            {
                int scoreHandleIndex = h;

                SetPositionScoreBracket(scoreHandleIndex);

                SetActiveScoreBracket(scoreHandleIndex, true);

                AnimationScoreBracket(scoreHandleIndex);

                break;
            }
        }
    }
    private Vector3 SetPositionScoreBracket(int index)
    {
        Vector3 scoreBracketPosition = transform.position + Vector3.up * (index * ScoreBracketHeight);

        _scoreBracketList[index].transform.position = scoreBracketPosition;

        return scoreBracketPosition;
    }
    private void AnimationScoreBracket(int index)
    {
        _scoreBracketList[index].transform.DOScale(new Vector3(1, 0.25f, 1), 0.3f).SetEase(Ease.InElastic);
    }
    private void SetActiveScoreBracket(int index, bool setActive)
    {
        _scoreBracketList[index].SetActive(setActive);
    }

    public void ReturnToPool(GameObject scoreBracket)
    {
        if (_scoreBracketList.Contains(scoreBracket))
        {
            scoreBracket.SetActive(false);
        }
    }
}
