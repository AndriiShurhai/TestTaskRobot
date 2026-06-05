using System;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour 
{
    [SerializeField] private Transform _headPositionPoint;
    [SerializeField] private Transform _bodyPositionPoint;
    [SerializeField] private Transform _legsPositionPoint;


    public Vector3 HeadPositionPoint => _headPositionPoint.position;
    public Vector3 BodyPositionPoint => _bodyPositionPoint.position;
    public Vector3 LegsPositionPoint => _legsPositionPoint.position;

}