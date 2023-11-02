using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject targetScore;
    [SerializeField] GameObject curentScore;
    [SerializeField] TextMeshProUGUI curentScoreText;

    private int _distanceCoefficient = -10;
    private float _targetCurentDistance;
    private string _closeDecimal = "F0";
    private void Update()
    {
        _targetCurentDistance = (targetScore.transform.position.y - curentScore.transform.position.y) * _distanceCoefficient;

        curentScoreText.text = _targetCurentDistance.ToString(_closeDecimal) + " M";
    }
}
