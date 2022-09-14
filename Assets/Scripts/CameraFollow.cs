using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _target;

    private Vector3 _cameraOffset;

    private void Awake()
    {
        _cameraOffset = transform.position - _target.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = _target.transform.position + _cameraOffset;
        transform.position = newPosition;
    }
}
