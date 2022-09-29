using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Entity", fileName = "Entity", order = 50)]
public class EntityData : ScriptableObject
{
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private string type;

    [SerializeField] private Sprite sprite;

    public string Title
    {
        get { return title; }
    }
    public string Description => description;

    public Sprite Sprite => sprite;
}
