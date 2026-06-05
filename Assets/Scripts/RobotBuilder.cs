using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor.Rendering;
using UnityEngine;

public class RobotBuilder : MonoBehaviour
{
    public static RobotBuilder Instance { get; private set; }

    public event Action<float, float> OnStatsChanged;

    [SerializeField] private Robot _robot;

    [SerializeField] private List<RobotPartData> _headParts;
    [SerializeField] private List<RobotPartData> _bodyParts;
    [SerializeField] private List<RobotPartData> _legsParts;


    private int _currentHeadIndex;
    private int _currentBodyIndex;
    private int _currentLegsIndex;

    private GameObject _currentHeadInstance;
    private GameObject _currentBodyInstance;
    private GameObject _currentLegsInstance;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        SpawnPart(RobotPartType.Head, 1);
        SpawnPart(RobotPartType.Body, _currentBodyIndex);
        SpawnPart(RobotPartType.Legs, 1);
    }

    private void SpawnPart(RobotPartType partType, int index)
    {
        RobotPartData currentPartData = null;
        Vector3 positionToSpawn = Vector3.zero;
        ref GameObject currentPartInstance = ref _currentHeadInstance;

        switch (partType)
        {
            case RobotPartType.Head:
                if (_headParts.Count == 0) return;
                currentPartData = _headParts[index];
                positionToSpawn = _robot.HeadPositionPoint;
                currentPartInstance = ref _currentHeadInstance;
                break;

            case RobotPartType.Body:
                if (_bodyParts.Count == 0) return;
                currentPartData = _bodyParts[index];
                positionToSpawn = _robot.BodyPositionPoint;
                currentPartInstance = ref _currentBodyInstance;
                break;
            case RobotPartType.Legs:
                if (_legsParts.Count == 0) return;
                currentPartData = _legsParts[index];
                positionToSpawn = _robot.LegsPositionPoint;
                currentPartInstance = ref _currentLegsInstance;
                break;  
        }

        if (currentPartInstance != null) Destroy(currentPartInstance);

        if (currentPartData != null && currentPartData.partPrefab != null)
        {
            currentPartInstance = Instantiate(currentPartData.partPrefab, positionToSpawn, Quaternion.identity, _robot.transform);
        }
    }
}