using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemEditor : EditorWindow
{
    [MenuItem("Tools/ItemData editor")]
    public static void OpenWindow()
    {
        var itemEditor = GetWindow<ItemEditor>();
        itemEditor.titleContent = new GUIContent("ItemData Editor.");
    }

    private void OnEnable()
    {
        Debug.Log($"ItemEditor enabled.");
        var element = this.rootVisualElement;
        element.style.flexDirection = FlexDirection.Row;

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

        element.Add(box);
        element.Add(box2);
    }

    private void OnGUI()
    {
        var toggle = EditorGUILayout.Toggle(true);
        
        Debug.Log($"ItemEditor works...");
    }
}
