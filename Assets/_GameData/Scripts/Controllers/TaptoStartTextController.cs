using UnityEngine;
using DG.Tweening;

public class TaptoStartTextController : MonoBehaviour
{
    [SerializeField] private GameObject topToStartText;
    void Start()
    {
        TapToStartTextAnimation();
    }
    private void OnEnable()
    {
        EventManager.Instance.OnGameStarted += SetActiveTapToText;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnGameStarted -= SetActiveTapToText;
    }
    private void TapToStartTextAnimation()
    {
        Sequence textRotateSquence = DOTween.Sequence();

        textRotateSquence.Append(transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 4), .4f));
        textRotateSquence.Join(transform.DOScaleY(1.25f, .4f));
        textRotateSquence.Append(transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, -4), .4f));

        textRotateSquence.SetLoops(-1, LoopType.Yoyo);
    }
    private void SetActiveTapToText()
    {
        topToStartText.SetActive(false);
    }


}
