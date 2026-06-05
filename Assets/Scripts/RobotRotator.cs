using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;


public class RobotRotator : MonoBehaviour, IDragHandler
{
    [SerializeField] private float _rotationSpeed = 0.5f;

    [SerializeField] private Transform _targetToRotate;

    public void OnDrag(PointerEventData eventData)
    {
        if (_targetToRotate == null) return;

        float deltaX = eventData.delta.x;

        _targetToRotate.Rotate(Vector3.up, -deltaX * _rotationSpeed, Space.World);
    }
}