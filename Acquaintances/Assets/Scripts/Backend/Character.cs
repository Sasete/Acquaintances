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

    public List<Trait> traits;

    public RelationEvent OnRelationFull;
    public RelationEvent OnRelationEmpty;
    public RelationEvent OnRelationChange;
    public delegate void RelationEvent();


    public void Init()
    {
        relation = 50;
    }

    public void AddRelation(int amount)
    {

        relation += amount;
        OnRelationChange?.Invoke();


        if(relation >= 100)
        {
            relation = 100;
            OnRelationFull?.Invoke();
        }

        if(relation <= 0)
        {
            relation = 0;
            OnRelationEmpty?.Invoke();
        }
    
    }

    public void Reset()
    {
        relation = 50;
    }

}
