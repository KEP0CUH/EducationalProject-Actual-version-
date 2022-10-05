using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemEditor : EditorWindow
{
    private static Texture2D icon;

    [MenuItem("Tools/ItemData editor")]
    public static void OpenWindow()
    {
        var itemEditor = GetWindow<ItemEditor>();
        itemEditor.titleContent = new GUIContent("ItemData Editor.");

        icon = Resources.Load<Sprite>("IconsItems/Minerals/Gold").texture;
    }

    private void OnEnable()
    {
        Debug.Log($"ItemEditor enabled.");
        var element = this.rootVisualElement;
        element.style.flexDirection = FlexDirection.Row;

        var label = new Label("1231");

        var box = new Box();
        box.style.flexGrow = 1f;
        box.style.flexShrink = 0f;
        box.style.flexBasis = 0f;
        box.style.flexDirection = FlexDirection.Column;

        var box2 = new Box();
        box2.style.flexGrow = 3f;
        box2.style.flexShrink = 0f;
        box2.style.flexBasis = 0f;
        var text = new TextField();
        text.focusable = false;
        box2.Add(new TextField());
        box2.Add(new TextField());
        box2.Add(new TextField());
        box.Add(text);
        box.Add(label);

        element.Add(box);
        element.Add(box2);

        var image = new VisualElement();
        image.style.width = 64;
        image.style.height = 64;
        image.style.backgroundImage = Resources.Load<Sprite>("IconsItems/Minerals/Gold").texture;

        box2.Add(image);

    }

    private void OnGUI()
    {
        var toggle = EditorGUILayout.Toggle(true);
        icon = Resources.Load<Sprite>("IconsItems/Minerals/Gold").texture;
        GUILayout.Label(icon);
        
        Debug.Log($"ItemEditor works...");
    }
}
