using UnityEngine;
using DG.Tweening;
public class ChestAnimationController : MonoBehaviour
{
    [SerializeField] Transform chestUp;
    private void Start()
    {
        Sequence openChestSequence = DOTween.Sequence();

        openChestSequence.SetDelay(1f);

        openChestSequence.Append(transform.DOMoveY(6f, .5f));
        openChestSequence.Join(transform.DORotate(Vector3.up * 180f, .5f));
        openChestSequence.Append(transform.DOMoveY(4.933f, .5f));
        openChestSequence.Join(transform.DORotate(Vector3.up * 360f, .5f));
        openChestSequence.Append(transform.DOShakeRotation(0.5f, 20, 25, 10));
        openChestSequence.Join(transform.DOScaleY(.9f, .5f));
        openChestSequence.Append(chestUp.transform.DORotate(Vector3.right * -135, .5f));
        openChestSequence.Join(transform.DOScaleY(.6f, .5f));

    }
}
