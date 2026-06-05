using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;


public class RobotStatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _weightText;
    [SerializeField] private TextMeshProUGUI _powerText;

    private void Start()
    {
        if (RobotBuilder.Instance != null)
        {
            RobotBuilder.Instance.OnStatsChanged += UpdateStats;
            RobotBuilder.Instance.RequestStatsUpdate();
        }
    }

    private void OnDestroy()
    {
        if (RobotBuilder.Instance != null)
        {
            RobotBuilder.Instance.OnStatsChanged -= UpdateStats;
        }
    }

    private void UpdateStats(float weight, float power)
    {
        _weightText.text = $"Weight: {weight:F1} kg";
        _powerText.text = $"Power: {power:F1} W";
    }
}