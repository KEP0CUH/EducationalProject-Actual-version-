using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class ItemEditor : EditorWindow
{
    private ScrollView scrollView;

    [MenuItem("Tools/Item Editor")]
    public static void OpenWindow()
    {
        var window = GetWindow<ItemEditor>();
        window.titleContent = new GUIContent("Item Editor");
    }

    private void OnEnable()
    {
        var root = this.rootVisualElement;
        root.style.flexDirection = FlexDirection.Row;

        var itemsListBox = new Box();
        itemsListBox.style.flexGrow = 1f;
        itemsListBox.style.flexShrink = 0f;
        itemsListBox.style.flexBasis = 0f;
        itemsListBox.style.flexDirection = FlexDirection.Column;


        var newItemBox = new Box();
        newItemBox.style.flexGrow = 3f;
        newItemBox.style.flexShrink = 0f;
        newItemBox.style.flexBasis = 0f;

        root.Add(itemsListBox);
        root.Add(newItemBox);

        SetupItemList(itemsListBox);
    }

    private void SetupItemList(Box parent)
    {
        var listLabel = new Label("Item List");
        listLabel.style.alignSelf = Align.Center;
        listLabel.style.unityFontStyleAndWeight = FontStyle.Bold;
        parent.Add(listLabel);

        scrollView = new ScrollView();
        scrollView.horizontalScrollerVisibility = ScrollerVisibility.Hidden;
        scrollView.style.flexGrow = 1f;
        parent.Add(scrollView);
    }


}

