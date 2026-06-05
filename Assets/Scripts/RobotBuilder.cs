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
        SpawnPart(RobotPartType.Head, _currentHeadIndex);
        SpawnPart(RobotPartType.Body, _currentBodyIndex);
        SpawnPart(RobotPartType.Legs, _currentLegsIndex);

        UpdateStats();
    }

    public void NextPart(RobotPartType type)
    {
        ChangePart(type, 1);
    }

    public void PreviousPart(RobotPartType type)
    {
        ChangePart(type, -1);
    }

    public void SetPartColor(RobotPartType type, Color color)
    {
        switch (type)
        {
            case RobotPartType.Head:
                if (_currentHeadInstance != null) _currentHeadInstance.GetComponent<PartColorChanger>().SetColor(color);
                break;
            case RobotPartType.Body:
                if (_currentBodyInstance != null) _currentBodyInstance.GetComponent<PartColorChanger>().SetColor(color);
                break;
            case RobotPartType.Legs:
                if (_currentLegsInstance != null) _currentLegsInstance.GetComponent<PartColorChanger>().SetColor(color);
                break;
        }
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

        if (currentPartInstance != null)
        {
            Destroy(currentPartInstance);
        }

        if (currentPartData != null && currentPartData.partPrefab != null)
        {
            currentPartInstance = Instantiate(currentPartData.partPrefab, positionToSpawn, Quaternion.identity, _robot.transform);
            currentPartInstance.transform.rotation = _robot.transform.rotation;

            if (currentPartInstance.GetComponent<PartColorChanger>() == null)
            {
                currentPartInstance.AddComponent<PartColorChanger>();
            }
        }
    }
    
    private void ChangePart(RobotPartType type, int direction)
    {
        switch (type)
        {
            case RobotPartType.Head:
                _currentHeadIndex = GetNextIndex(_currentHeadIndex, direction, _headParts.Count);
                SpawnPart(type, _currentHeadIndex);
                break;
            case RobotPartType.Body:
                _currentBodyIndex = GetNextIndex(_currentBodyIndex, direction, _bodyParts.Count);
                SpawnPart(type, _currentBodyIndex);
                break;
            case RobotPartType.Legs:
                _currentLegsIndex = GetNextIndex(_currentLegsIndex, direction, _legsParts.Count);
                SpawnPart(type, _currentLegsIndex);
                break;
        }

        UpdateStats();
    }

    private int GetNextIndex(int currentIndex, int direction, int listCount)
    {
        if (listCount == 0) return 0;

        int newIndex = (currentIndex + direction) % listCount;
        if (newIndex < 0) newIndex += listCount;
        return newIndex;
    }

    private void UpdateStats()
    {
        float totalWeight = 0f;
        float totalPower = 0f;

        if (_headParts.Count > 0)
        {
            totalWeight += _headParts[_currentHeadIndex].weight;
            totalPower += _headParts[_currentHeadIndex].power;
        }

        if (_bodyParts.Count > 0)
        {
            totalWeight += _bodyParts[_currentBodyIndex].weight;
            totalPower += _bodyParts[_currentBodyIndex].power;
        }

        if (_legsParts.Count > 0)
        {
            totalWeight += _legsParts[_currentLegsIndex].weight;
            totalPower += _legsParts[_currentLegsIndex].power;
        }

        OnStatsChanged?.Invoke(totalWeight, totalPower);
    }
}