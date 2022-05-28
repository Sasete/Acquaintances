using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Acquaintances/Character", order = 0)]
public class Character : ScriptableObject
{
    
    
    public string Name;

    public string Surname;

    public Trait[] traits;


}
