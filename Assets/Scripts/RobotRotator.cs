using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;


public class RobotRotator : MonoBehaviour, IDragHandler
{
    [SerializeField] private float rotationSpeed = 0.5f;

    [SerializeField] private Transform targetToRotate;

    public void OnDrag(PointerEventData eventData)
    {
        if (targetToRotate == null) return;

        float deltaX = eventData.delta.x;

        targetToRotate.Rotate(Vector3.up, -deltaX * rotationSpeed, Space.World);
    }
}