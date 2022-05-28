using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Card", menuName = "Acquaintances/Cards/Card", order = 2)]
public class Card : ScriptableObject
{
    
    [System.Serializable]
    public class Effect
    {

        public Trait trait;

        [FoldoutGroup("Effect")]
        public bool includeCounter;

        [FoldoutGroup("Effect")]
        public int effect;

    }


    [PreviewField(80, ObjectFieldAlignment.Left), HideLabel, HorizontalGroup("HorizontalGroup")]
    public Sprite image;

    [VerticalGroup("HorizontalGroup/VerticalGroup")]
    public string title;
    [VerticalGroup("HorizontalGroup/VerticalGroup")]
    public string description;

    public List<Effect> effects;
    public Effect FindEffect(Trait trait) => effects.Find( (eff)=> eff.trait == trait );


}
