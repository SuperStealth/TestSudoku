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

    public Button CellButton { get => button; }
    public Action OnButtonPressed;

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

    private void ButtonPressed()
    {
        OnButtonPressed?.Invoke();
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(ButtonPressed);
    }
}
