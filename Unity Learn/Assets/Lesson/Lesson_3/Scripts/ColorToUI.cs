using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ColorToUI : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI _currentColorText;
    [SerializeField] private Material _material;
    [SerializeField] private RawImage _rawImage;

    private void Awake()
    {
        ChangeImageColor();
    }

    private void ChangeImageColor()
    {
        _rawImage.color = _material.color;
    }

    private void OnDisable()
    {
        _material.color = Color.red;
        _rawImage.color = _material.color;
    }
    
    public void OnYellowButtonClick()
    {
        _material.color = Color.yellow;
        _rawImage.color = _material.color;
    }

    public void OnBlueButtonClick()
    {
        _material.color = Color.blue;
        _rawImage.color = _material.color;
    }
    
    public void OnGreenButtonClick()
    {
        _material.color = Color.green;
        _rawImage.color = _material.color;
    }
    
    public void OnBlackButtonClick()
    {
        _material.color = Color.black;
        _rawImage.color = _material.color;
    }
}
