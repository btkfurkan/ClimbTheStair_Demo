using UnityEngine;
using DG.Tweening;
public class ChestAnimationController : MonoBehaviour
{
    [SerializeField] public Transform chestUp;
    private void OnEnable()
    {
        EventManager.Instance.OnOpenChestAnimation += OnChestAnimation;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnOpenChestAnimation -= OnChestAnimation;
    }
    public void OnChestAnimation()
    {
        Sequence openChestSequence = DOTween.Sequence();

        openChestSequence.Rewind();

        openChestSequence.Append(transform.DOMoveY(6f, .5f));
        openChestSequence.Join(transform.DORotate(Vector3.up * -210f, .5f));
        openChestSequence.Append(transform.DOMoveY(5.15f, .5f));
        openChestSequence.Join(transform.DORotate(Vector3.up * 360f, .5f));
        openChestSequence.Append(transform.DOShakeRotation(0.5f, 20, 25, 10));
        openChestSequence.Join(transform.DOScaleY(.9f, .5f));
        openChestSequence.Append(chestUp.transform.DORotate(Vector3.right * -60, .5f));
        openChestSequence.Join(transform.DOScaleY(.6f, .5f));

        openChestSequence.Play();
    }
}
