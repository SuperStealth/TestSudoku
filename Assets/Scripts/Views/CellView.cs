using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private int cellNumber;

    public Button CellButton { get => button; }
    public Action<int> OnButtonPressed;

    private void Awake()
    {
        button.onClick.AddListener(ButtonPressed);
    }

    public void SetCellValue(int value)
    {
        text.text = value.ToString();
    }

    public void SetCellColor(bool isCorrect)
    {
        text.color = isCorrect ? Color.black : Color.red;
    }

    public void SetCellBackgroundColor(bool isSelected)
    {
        button.image.color = isSelected ? Color.yellow : Color.white;
    }

    private void ButtonPressed()
    {
        OnButtonPressed?.Invoke(cellNumber);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(ButtonPressed);
    }
}
