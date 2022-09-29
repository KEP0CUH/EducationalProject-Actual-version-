using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoItemWindow : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI type;

    public void Init(ItemData data)
    {
        icon.sprite = data.Icon;
        title.text = data.name;
        description.text = data.Description;
        type.text = data.Kind.ToString();
    }
}
