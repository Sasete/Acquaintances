using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public CharacterBehaviour[] characters;

    public DeckBehaviour deck;

    public Transform handArea;
    public GameObject cardPrefab;

    public void Start()
    {

        foreach (CharacterBehaviour character in characters)
            character.Init();


    }

}
