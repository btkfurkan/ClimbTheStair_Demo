using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float targetHeight = 10f;
    public float lerpSpeed = 1.0f;

    private void LateUpdate()
    {

        Vector3 currentPos = transform.position;

        Vector3 targetPos = new Vector3(currentPos.x, targetHeight, currentPos.z);
        transform.position = Vector3.Lerp(currentPos, targetPos, lerpSpeed * Time.deltaTime);
    }
}
