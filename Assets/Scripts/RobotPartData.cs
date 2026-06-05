using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "New Robot Part", menuName = "Robot Part Data")]
public class RobotPartData : ScriptableObject
{
    public GameObject partPrefab;

    public RobotPartType partType;

    public float weight;

    public float power;

    public string partName;
}