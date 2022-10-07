using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Items
{
    [Serializable]
    public class ItemData
    {
        public string Name;
    }

    public class ItemsFile
    {
        public List<ItemData> Items;

        public void Write(List<ItemData> items)
        {
            Items = new List<ItemData>(items);
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

        private void OnKindChanged()
        {
            Debug.Log($"Kind was changed.");
        }

        private void OnEnable()
        {
            items = new List<Items.ItemData>();
            scrollView = new ScrollView();

            Debug.Log($"ItemEditor enabled.");

            var element = this.rootVisualElement;
            element.style.flexDirection = FlexDirection.Row;


            var box1 = new Box();
            box1.style.flexGrow = 3f;
            box1.style.flexShrink = 0f;
            box1.style.flexBasis = 0f;
            box1.style.flexDirection = FlexDirection.Column;
            box1.style.borderLeftColor = new StyleColor(UnityEngine.Color.gray);
            box1.style.borderLeftWidth = 6;
            box1.style.borderRightColor = new StyleColor(UnityEngine.Color.gray);
            box1.style.borderRightWidth = 6;

            var box2 = new Box();
            box2.style.flexGrow = 3f;
            box2.style.flexShrink = 0f;
            box2.style.flexBasis = 0f;

            var text = new TextField();
            box2.Add(text);

            var boxItemsScroll = new Box();
            boxItemsScroll.style.flexGrow = 2f;
            boxItemsScroll.style.flexShrink = 0f;
            boxItemsScroll.style.flexBasis = 0f;

            SetupItemList(boxItemsScroll);
            SetupFields(box1);



            element.Add(boxItemsScroll);
            element.Add(box1);
            element.Add(box2);
            LoadData();
        }

        private void OnSelectionChange()
        {
            Debug.Log("$$$$");
        }
        /*{
            
        }*/

        private void SetupFields(Box parent)
        {
            var image = new VisualElement();
            image.style.width = 64;
            image.style.height = 64;
            image.style.backgroundImage = Resources.Load<Sprite>("IconsItems/Minerals/Gold").texture;
            parent.Add(image);  

            var enumField = new EnumField(ItemKind.Gold);
            //enumField.
            parent.Add(enumField);
            Debug.Log(enumField.focusable);

            var kind = enumField.value.ToString();
            var path =$"IconsItems/Minerals/{kind}";
            image.style.backgroundImage = Resources.Load<Sprite>(path).texture;

            Debug.Log(enumField.value);

            var countField = new IntegerField(5);
            parent.Add(countField);
            //countField.value.

            var field = new Vector3Field();
            parent.Add(field);

            var colorField = new ColorField();
            parent.Add(colorField);

            var nameField = new TextField();
            parent.Add(nameField);

            var refreshButton = new Button();
            refreshButton.text = "Refresh data";
            refreshButton.clicked += () =>
            {
                var kind = enumField.value.ToString();
                var path = $"IconsItems/Minerals/{kind}";
                image.style.backgroundImage = Resources.Load<Sprite>(path).texture;
            };
            parent.Add(refreshButton);

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
                    SaveData();
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
                SaveData();
            };

            itemElement.Add(removeButton);

            var nameButton = new Button();
            nameButton.text = item.Name;
            nameButton.style.flexGrow = 1;
            itemElement.Add(nameButton);

            scrollView.Add(itemElement);
        }

        private void SaveData()
        {
            Debug.Log(Application.dataPath);
            var path = Application.dataPath + "/Resources/Storages/listItems.json";

            var itemsFile = new ItemsFile();
            itemsFile.Write(items);

            var itemsFileAsJson = JsonUtility.ToJson(itemsFile,true);
            System.IO.File.WriteAllText(path, itemsFileAsJson);
        }

        private void LoadData()
        {
            var path = Application.dataPath + "/Resources/Storages/listItems.json";

            if(System.IO.File.Exists(path))
            {
                var file = System.IO.File.ReadAllText(path);

                items = JsonUtility.FromJson<ItemsFile>(file).Items;

                foreach(var item in items)
                {
                    CreateListItem(item);
                }
            }
        }
    }
}