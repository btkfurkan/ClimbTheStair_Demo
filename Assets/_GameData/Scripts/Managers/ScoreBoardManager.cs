using DG.Tweening;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ScoreBoardManager : MonoBehaviour
{
    [Header("Skor Tabelas� Ayarlar�")]
    [SerializeField] private PoolManager poolManager;
    [SerializeField] private GameObject scoreTable;

    public float ScoreBoardHeight;
    public float offsetTable;
    public float animationDuration;

    private int _objectScoreBoard = 1;
    private int _currentBoardIndex = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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

            this.scoreTable.transform.DOMoveY(scoreBoard.transform.position.y + offsetTable, animationDuration);
        }
    }
    private Vector3 SetPositionScoreBoard(int index)
    {
        Vector3 scoreBoardPosition = transform.position + Vector3.up * (index * ScoreBoardHeight);

        return scoreBoardPosition;
    }
}
