using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class PartColorChanger : MonoBehaviour
{
    private Renderer _partRenderer;
    private MaterialPropertyBlock _materialPropertyBlock;   


    private void Awake()
    {
        _partRenderer = GetComponent<Renderer>();
        _materialPropertyBlock = new();
    }

    public void SetColor(Color newColor)
    {
        _partRenderer.GetPropertyBlock(_materialPropertyBlock);

        _materialPropertyBlock.SetColor("_BaseColor", newColor);

        _partRenderer.SetPropertyBlock(_materialPropertyBlock);
    }
}