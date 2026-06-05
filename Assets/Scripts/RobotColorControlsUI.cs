using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class RobotColorControlsUI : MonoBehaviour
{
    [SerializeField] private GameObject headColorsContainer;
    [SerializeField] private GameObject bodyColorsContainer;
    [SerializeField] private GameObject legsColorsContainer;



    private void Awake()
    {
        foreach (Transform colorTransform in headColorsContainer.transform)
        {
            GameObject colorOption = colorTransform.gameObject;
            var button = colorOption.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => OnColorSelected(RobotPartType.Head, colorOption.GetComponent<Image>().color));
            }
        }
        foreach (Transform colorTransform in bodyColorsContainer.transform)
        {
            GameObject colorOption = colorTransform.gameObject;
            var button = colorOption.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => OnColorSelected(RobotPartType.Body, colorOption.GetComponent<Image>().color));
            }
        }
        foreach (Transform colorTransform in legsColorsContainer.transform)
        {
            GameObject colorOption = colorTransform.gameObject;
            var button = colorOption.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => OnColorSelected(RobotPartType.Legs, colorOption.GetComponent<Image>().color));
            }
        }
    }


    private void OnColorSelected(RobotPartType partType, Color color)
    {
        Debug.Log($"Color selected for {partType}: {color}");   
        switch (partType)
        {
            case RobotPartType.Head:
                RobotBuilder.Instance.SetPartColor(RobotPartType.Head, color);
                break;
            case RobotPartType.Body:
                RobotBuilder.Instance.SetPartColor(RobotPartType.Body, color);
                break;
            case RobotPartType.Legs:
                RobotBuilder.Instance.SetPartColor(RobotPartType.Legs, color);
                break;
        }
    }
}