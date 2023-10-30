using DG.Tweening;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _lookRotationOffset = new Vector3(0, 0, 0);
    private PlayerAnimationController _animatorController;
    private void OnEnable()
    {
        EventManager.Instance.OnStairPlaced += OnStairPlacedHandler;
    }

    private void Awake()
    {
        _animatorController = new PlayerAnimationController(GetComponent<Animator>());
    }

    private void OnDisable()
    {
        EventManager.Instance.OnStairPlaced -= OnStairPlacedHandler;
    }

    private void OnStairPlacedHandler(Vector3 stairPosition,Vector3 stairRotation)
    {
        transform.position = stairPosition;
        transform.rotation = Quaternion.LookRotation(stairRotation);
        _animatorController.PlayAnim(PlayerAnimationController.Climb);
        DOVirtual.DelayedCall(.25f, () =>
        {
            _animatorController.PlayAnim(PlayerAnimationController.Idle);
        });
    }
}
