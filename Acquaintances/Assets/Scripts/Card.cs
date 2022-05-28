using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Acquaintances/Card", order = 2)]
public class Card : ScriptableObject
{
    
    [System.Serializable]
    public class Effect
    {

        public Trait trait;

        public bool includeCounter;

        public int effect;

    }
    

    public string title;

    public List<Effect> effects;
    public Effect FindEffect(Trait trait) => effects.Find( (eff)=> eff.trait == trait );


}
