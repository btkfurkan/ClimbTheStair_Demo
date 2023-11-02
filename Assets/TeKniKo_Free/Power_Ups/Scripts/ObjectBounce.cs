using UnityEngine;

public class ObjectBounce : MonoBehaviour
{
    public float BounceSpeed = 8;
    public float BounceAmplitude = 0.05f;
    public float RotationSpeed = 90;

    private float _startHeight;
    private float _timeOffset;

    void Start()
    {
        _startHeight = transform.localPosition.y;

        _timeOffset = Random.value * Mathf.PI * 2;
    }
    void Update()
    {
        float finalheight = _startHeight + Mathf.Sin(Time.time * BounceSpeed + _timeOffset) * BounceAmplitude;

        var position = transform.localPosition;

        position.y = finalheight;

        transform.localPosition = position;

        Vector3 rotation = transform.localRotation.eulerAngles;

        rotation.y += RotationSpeed * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }
}
