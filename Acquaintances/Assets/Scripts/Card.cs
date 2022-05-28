using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Card", menuName = "Acquaintances/Card", order = 2)]
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
    

    public string title;

    public List<Effect> effects;
    public Effect FindEffect(Trait trait) => effects.Find( (eff)=> eff.trait == trait );


}
