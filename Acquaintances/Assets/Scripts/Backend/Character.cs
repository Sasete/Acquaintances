using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Character", menuName = "Acquaintances/Character", order = 0)]
public class Character : ScriptableObject
{

    public enum Sex
    {
        Male,
        Female
    }

    [HorizontalGroup("HorizontalGroup")]
    [PreviewField(70, ObjectFieldAlignment.Left), HideLabel]
    public Sprite view;

    [VerticalGroup("HorizontalGroup/VerticalGroup"), LabelWidth(120)]
    public string characterName;

    [VerticalGroup("HorizontalGroup/VerticalGroup"), LabelWidth(30)]
    public Sex sex;

    [VerticalGroup("HorizontalGroup/VerticalGroup"), LabelWidth(30)]
    [PropertyRange(0, 100)]
    public int relation = 50;

    public float Relation { get { return (float)relation / 100; } }

    public Trait[] traits;


    public void Init()
    {
        relation = 50;
    }


}
