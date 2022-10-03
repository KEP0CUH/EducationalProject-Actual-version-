using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipInInventoryWindow : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Image icon;
    [SerializeField] private Text size;
    [SerializeField] private Text armor;
    [SerializeField] private Text shields;
    [SerializeField] private Text structure;
    [SerializeField] private Text speed;
    [SerializeField] private Text energy;
    [SerializeField] private Text cpu;

    private Ship ship;

    public ShipInInventoryWindow Init(Ship ship)
    {
        this.ship = ship;
        this.UpdateDataFields();


        return this;
    }

    private void UpdateDataFields()
    {
        var data = this.ship.State.Data;

        this.icon.sprite = data.Icon;
        this.title.text = $"<color=orange>{data.Title}</color>";
        this.size.text = $"      Трюм         <color=orange>{data.Size}</color>";
        this.armor.text = $"      Броня        <color=orange>{data.Armor}</color>";
        this.shields.text = $"      Щиты         <color=orange>{data.Shields}%</color>";
        this.structure.text = $"      Структура    <color=orange>{data.Structure}</color>";
        this.speed.text = $"      Скорость     <color=orange>{data.Speed}</color>";
        this.energy.text = $"      Энергия      <color=orange>{data.Energy}</color>";
        this.cpu.text = $"      ЦП           <color=orange>{data.Cpu}</color>";
    }
}
