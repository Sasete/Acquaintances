using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

public class CharacterBehaviour : MonoBehaviour
{


    public Character character;


    [FoldoutGroup("Hierarchy Members")]
    public SpriteRenderer spriteRenderer;

    [FoldoutGroup("Hierarchy Members")]
    public TextMeshProUGUI nameField;



    public void Init()
    {

        nameField.text = character.characterName;
        spriteRenderer.sprite = character.view;

    }


}
