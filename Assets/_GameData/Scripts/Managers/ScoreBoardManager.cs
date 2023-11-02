using DG.Tweening;
using UnityEngine;

public class ScoreBoardManager : MonoBehaviour
{
    [Header("Score Table Settings")]
    [SerializeField] private PoolManager poolManager;
    [SerializeField] private GameObject scoreTable;

    public float ScoreBoardHeight;
    public float OffsetTable;
    public float AnimationDuration;

    private bool _isGameActive;
    private int _objectScoreBoard = 1;
    private int _currentBoardIndex = 0;
    private void Update()
    {
        _isGameActive = MenuController.Instance.GetGameState();

        if (Input.GetKeyDown(KeyCode.Space) && _isGameActive)
        {
            CreateScoreBoard(_currentBoardIndex);

            _currentBoardIndex++;
        }
    }
    private void CreateScoreBoard(int index)
    {
        GameObject scoreBoard = poolManager.GetPooledObject(_objectScoreBoard);

        if (scoreBoard != null)
        {
            scoreBoard.transform.position = SetPositionScoreBoard(index);

            scoreTable.transform.DOMoveY(scoreBoard.transform.position.y + OffsetTable, AnimationDuration);
        }
    }
    private Vector3 SetPositionScoreBoard(int index)
    {
        Vector3 scoreBoardPosition = transform.position + Vector3.up * (index * ScoreBoardHeight);

        return scoreBoardPosition;
    }
}
