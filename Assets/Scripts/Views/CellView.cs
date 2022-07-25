using DG.Tweening;
using System;
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

    private Sequence tweenSequence;

    private void Awake()
    {
        button.onClick.AddListener(ButtonPressed);
    }

    public void SetCellValue(int value)
    {
        if (value == 0)
        {
            text.text = "";
        }
        else
        {
            text.text = value.ToString();
        }
    }

    public void SetCellColor(bool isCorrect)
    {
        text.color = isCorrect ? Color.black : Color.red;
    }

    public void TweenCellHinted()
    {
        if (tweenSequence != null && !tweenSequence.IsComplete())
            tweenSequence.Kill();
        text.color = Color.green;
        tweenSequence = DOTween.Sequence();
        tweenSequence.Append(text.DOColor(Color.black, 1f));
        tweenSequence.Append(text.DOColor(Color.green, 1f));
        tweenSequence.Append(text.DOColor(Color.black, 1f));
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
        if (tweenSequence != null)
            tweenSequence.Kill();
    }
}
