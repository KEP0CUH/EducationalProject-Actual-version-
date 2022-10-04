using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeWindow : MonoBehaviour
{
    Action<ItemKind, int> makeTransaction;
    private ItemKind kind;
    private int count;
    [SerializeField] private Image icon;
    [SerializeField] private Text countTextField;
    [SerializeField] private InputField countInputField;
    [SerializeField] private Slider sliderCount;
    [SerializeField] private Text action;
    [SerializeField] private Button confirm;
    [SerializeField] private Button cancel;

    public TradeWindow Init(Action<ItemKind,int> makeTransaction, ItemKind kind,Sprite icon, int count, string action)
    {
        this.makeTransaction = makeTransaction;
        this.kind = kind;
        this.icon.sprite = icon;
        this.count = count;
        this.countInputField.text = count.ToString().ToUpper();
        this.action.text = action;


        confirm.onClick.AddListener(ConfirmTransaction);
        cancel.onClick.AddListener(CancelTransaction);

        sliderCount.minValue = 1;
        sliderCount.maxValue = count;
        sliderCount.wholeNumbers = true;
        sliderCount.value = 1;
        sliderCount.onValueChanged.AddListener((content) => UpdateTextField(content));

        countInputField.text = sliderCount.value.ToString();
        countInputField.onValueChanged.AddListener((content) => UpdateSlider(content));

        return this;
    }

    private void ConfirmTransaction()
    {
        this.gameObject.SetActive(false);

        try
        {
            var countForTransaction = int.Parse(countInputField.text);
            this.makeTransaction.Invoke(kind, countForTransaction);
            this.makeTransaction = null;
        }
        catch (Exception ex)
        {
            Debug.Log($"Неудачный парсинг числа предметов: {ex}");
        }
    }

    private void CancelTransaction()
    {
        this.gameObject.SetActive(false);
    }

    private void UpdateTextField(float a)
    {
        countInputField.GetComponent<InputField>().text = a.ToString();
    }

    private void UpdateSlider(string content)
    {
        try
        {
            sliderCount.GetComponent<Slider>().value = int.Parse(content);
        }
        catch (System.FormatException ex)
        {
            Debug.Log($"{ex.ToString().SetColor(Color.Red)}");
        }
    }

}
