using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class RobotPartsControlsUI : MonoBehaviour
{
    [Header("Head Controls")]
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    [Header("Body Controls")]
    [SerializeField] private Button bodyLeftButton;
    [SerializeField] private Button bodyRightButton;

    [Header("Legs Controls")]
    [SerializeField] private Button legsLeftButton;
    [SerializeField] private Button legsRightButton;


    private void Start()
    {
        leftButton.onClick.AddListener(() => RobotBuilder.Instance.PreviousPart(RobotPartType.Head));
        rightButton.onClick.AddListener(() => RobotBuilder.Instance.NextPart(RobotPartType.Head));

        bodyLeftButton.onClick.AddListener(() => RobotBuilder.Instance.PreviousPart(RobotPartType.Body));
        bodyRightButton.onClick.AddListener(() => RobotBuilder.Instance.NextPart(RobotPartType.Body));

        legsLeftButton.onClick.AddListener(() => RobotBuilder.Instance.PreviousPart(RobotPartType.Legs));
        legsRightButton.onClick.AddListener(() => RobotBuilder.Instance.NextPart(RobotPartType.Legs));
    }

}