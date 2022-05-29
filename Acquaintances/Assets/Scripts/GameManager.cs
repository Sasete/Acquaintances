using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager manager;

    public List<Character> characterList;

    public List<CharacterBehaviour> characters;

    public DeckBehaviour deck;

    public Transform handArea;
    public GameObject cardPrefab;

    public GameObject gameOverObject;
    public GameObject winObject;

    public void Start()
    {

        if(manager != null)
        {
            Destroy(gameObject);
            return;
        }

        manager = this;

        foreach (CharacterBehaviour character in characters)
        {

            if(characterList.Count <= 0)
                break;

            Character pulledCharacter = characterList[Random.Range(0, characterList.Count)];

            character.character = pulledCharacter;
            characterList.Remove(pulledCharacter);

            character.Init();
            character.character.OnRelationEmpty += GameOver;
            character.character.OnRelationFull += Win;
        }

        deck.Shuffle();
        deck.DrawCards(5);

        UpdateHand();

    }

    public void UpdateHand()
    {

        foreach(Transform tr in handArea.GetComponentsInChildren<Transform>())
            if( tr != handArea)
                Destroy(tr.gameObject);

        int order = 0;
        foreach(Card card in deck.deck.Hand)
        {
            CardBehaviour cardBehaviour = PrepareCard(card);

            Vector3 pos = cardBehaviour.transform.localPosition;
            pos.x += 8 * order;
            cardBehaviour.transform.localPosition = pos;

            order += 1;
        }

    }

    public CardBehaviour PrepareCard(Card card)
    {
        CardBehaviour cardBehaviour = Instantiate(cardPrefab, handArea).GetComponent<CardBehaviour>();

        cardBehaviour.transform.localPosition = Vector3.zero;

        cardBehaviour.card = card;
        cardBehaviour.Init();

        return cardBehaviour;
    }


    public void Use(Card card)
    {

        List<CharacterBehaviour> effectedOnes = new List<CharacterBehaviour>();

        foreach(Card.Effect effect in card.effects)
        {

            foreach(CharacterBehaviour character in characters)
            {

                bool effected = false;

                character.Effect(effect, ref effected);
                
                if(effected && !effectedOnes.Contains(character))
                    effectedOnes.Add(character);

            }
                
            // List<CharacterBehaviour> effectedCharacters = characters.FindAll((character)=> character.character.traits.Contains(effect.trait) );

        }

        foreach(CharacterBehaviour character in effectedOnes)
        {

            DialogueBox.DialogueEvent talk = ()=> 
            {

                character.Talk();
                DialogueBox.dialogueBox.OnFinalize += character.StopTalking;
                
                DialogueBox.dialogueBox.Init(character.character.reactions.Find((reaction)=>reaction.card == card).reaction, character.talkPosition.position);

            };

            DialogueBox.dialogueBox.reg.Add(talk);

        }

        effectedOnes[0].Talk();
        DialogueBox.dialogueBox.OnFinalize += effectedOnes[0].StopTalking;

        DialogueBox.dialogueBox.Init(effectedOnes[0].character.reactions.Find((reaction)=>reaction.card == card).reaction, effectedOnes[0].talkPosition.position);


        deck.deck.Use(card);
        deck.deck.Draw();
        UpdateHand();



    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        gameOverObject.SetActive(true);
    }

    public void Win()
    {
        Debug.Log("Congratulations!");
        winObject.SetActive(true);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
