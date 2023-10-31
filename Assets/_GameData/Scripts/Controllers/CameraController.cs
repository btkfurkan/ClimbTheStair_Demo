using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : CinemachineExtension
{
    [ExecuteInEditMode]
    [SaveDuringPlay]
    [AddComponentMenu("")]

    [Tooltip("Lock the camera's X and Z position to these values")]
    public Vector2 m_Position = new Vector2(10, 10);

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.x = m_Position.x;
            pos.z = m_Position.y;
            state.RawPosition = pos;
        }
    }
}
