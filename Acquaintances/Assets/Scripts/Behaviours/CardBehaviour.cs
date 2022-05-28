using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

public class CardBehaviour : MonoBehaviour
{

    public Card card;

    [FoldoutGroup("Hierarchy Members")]
    public TextMeshPro title;
    [FoldoutGroup("Hierarchy Members")]
    public TextMeshPro description;
    [FoldoutGroup("Hierarchy Members")]
    public SpriteRenderer cardImage;
    
    [ContextMenu("Build")]
    public void Init()
    {

        title.text = card.title;
        description.text = card.description;
        cardImage.sprite = card.image;

    }

    [ContextMenu("Use")]
    public void Use()
    {
        GameManager.manager.Use(card);

        Destroy(gameObject);
    }


    private void OnMouseUp() 
    {
        Use();
    }

}
