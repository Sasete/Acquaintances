using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Acquaintances/Character", order = 0)]
public class Character : ScriptableObject
{

    [Range(0, 100)]
    public int relation = 50;

    public Trait[] traits;


    public void Init()
    {
        relation = 50;
    }


}
