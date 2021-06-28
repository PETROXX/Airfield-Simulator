using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class Ring : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _height;

    [SerializeField] private GameObject _heightPanel;
    [SerializeField] private TMP_Text _heightText;

    public void OnPointerClick(PointerEventData eventData)
    {
        _heightPanel.SetActive(!_heightPanel.activeInHierarchy);
    }

    private void Start()
    {
        _heightPanel.SetActive(false);
        _height = UnityEngine.Random.Range(0, _maxHeight);
        _heightText.text = $"Height: {Math.Round(_height, 2)} m";
    }
}
