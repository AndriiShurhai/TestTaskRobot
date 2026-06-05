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
        RegisterColorButtons(headColorsContainer, RobotPartType.Head);
        RegisterColorButtons(bodyColorsContainer, RobotPartType.Body);
        RegisterColorButtons(legsColorsContainer, RobotPartType.Legs);
    }

    private void RegisterColorButtons(GameObject container, RobotPartType partType)
    {
        foreach (Transform t in container.transform)
        {
            var go = t.gameObject;
            var button = go.GetComponent<Button>();
            if (button == null) continue;
            var color = go.GetComponent<Image>().color;
            button.onClick.AddListener(() => RobotBuilder.Instance.SetPartColor(partType, color));
        }
    }
}