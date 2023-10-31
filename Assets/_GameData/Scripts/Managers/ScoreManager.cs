using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject targetScore;
    [SerializeField] GameObject curentScore;
    [SerializeField] TextMeshProUGUI curentScoreText;

    private float _targetCurentDistance;
    private string _closeDecimal = "F0";
    private void Start()
    {

    }
    private void Update()
    {
        _targetCurentDistance = (targetScore.transform.position.y - curentScore.transform.position.y) * -10;

        curentScoreText.text = _targetCurentDistance.ToString(_closeDecimal);
    }
}
