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


    [PreviewField(80, ObjectFieldAlignment.Right), HideLabel, HorizontalGroup("HorizontalGroup")]
    public Sprite image;

    [VerticalGroup("VerticalGroup"), LabelWidth(50)]
    public string title;

    public List<Effect> effects;
    public Effect FindEffect(Trait trait) => effects.Find( (eff)=> eff.trait == trait );


}
