using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Items
{
    [Serializable]
    public class ItemData
    {
        public string Name;
        public Sprite Icon;
    }
}

public class ItemEditor : EditorWindow
{
    private static Texture2D icon;

    private List<Items.ItemData> items;
    private ScrollView scrollView;

    [MenuItem("Tools/ItemData editor")]
    public static void OpenWindow()
    {
        var itemEditor = GetWindow<ItemEditor>();
        itemEditor.titleContent = new GUIContent("ItemData Editor.");

        icon = Resources.Load<Sprite>("IconsItems/Minerals/Gold").texture;
    }

    private void OnEnable()
    {
        items = new List<Items.ItemData>();
        scrollView = new ScrollView();

        Debug.Log($"ItemEditor enabled.");

        var element = this.rootVisualElement;
        element.style.flexDirection = FlexDirection.Row;


        var box1 = new Box();
        box1.style.flexGrow = 1f;
        box1.style.flexShrink = 0f;
        box1.style.flexBasis = 0f;
        box1.style.flexDirection = FlexDirection.Column;


        var label = new Label("Название");
        label.style.height = 32;
        box1.Add(label);
        var labelIcon = new Label("Спрайт");
        labelIcon.style.height = 64;
        box1.Add(labelIcon);



        var box2 = new Box();
        box2.style.flexGrow = 3f;
        box2.style.flexShrink = 0f;
        box2.style.flexBasis = 0f;

        var text = new TextField();
        box2.Add(text);

        
        var image = new VisualElement();
        image.style.width = 64;
        image.style.height = 64;
        image.style.backgroundImage = Resources.Load<Sprite>("IconsItems/Minerals/Gold").texture;
        box2.Add(image);

        var boxItemsScroll = new Box();
        boxItemsScroll.style.flexGrow = 2f;
        boxItemsScroll.style.flexShrink = 0f;
        boxItemsScroll.style.flexBasis = 0f;
        
        SetupItemList(boxItemsScroll);
        SetupFields(box1);



        element.Add(boxItemsScroll);
        element.Add(box1);
        element.Add(box2);


    }

    private void SetupFields(Box parent)
    {
        var newItemLabel = new Label("New Item");
        newItemLabel.style.alignSelf = Align.Center;
        parent.Add(newItemLabel);


        List<string> fields = new List<string>(Enum.GetNames(typeof(ItemKind)));

        var kin = new DropdownField(fields,0);
        
        parent.Add(kin);
        


        var nameField = new TextField();
        parent.Add(nameField);

        var saveButton = new Button();
        saveButton.text = "Save item";
        saveButton.clicked += () =>
        {
            if (string.IsNullOrWhiteSpace(nameField.value) == false)
            {
                var item = new Items.ItemData();
                item.Name = nameField.value;

                items.Add(item);

                nameField.value = "";

                CreateListItem(item);
            }
        };

        parent.Add(saveButton);
    }

    private void SetupItemList(Box parent)
    {
        var mainLabel = new Label("Item List");
        mainLabel.style.fontSize = 14;
        mainLabel.style.unityFontStyleAndWeight = FontStyle.Bold;
        parent.Add(mainLabel);

        scrollView.horizontalScrollerVisibility = ScrollerVisibility.Hidden;
        scrollView.style.flexGrow = 1f;

        parent.Add(scrollView);
    }

    void CreateListItem(Items.ItemData item)
    {
        var itemElement = new VisualElement();
        itemElement.style.flexDirection = FlexDirection.Row;
        itemElement.focusable = true;

        var removeButton = new Button();
        removeButton.text = "-";
        removeButton.clicked += () =>
        {
            scrollView.contentContainer.Remove(itemElement);
            items.Remove(item);
        };

        itemElement.Add(removeButton);

        var nameButton = new Button();
        nameButton.text = item.Name;
        nameButton.style.flexGrow = 1;
        itemElement.Add(nameButton);

        scrollView.Add(itemElement);
    }

}
