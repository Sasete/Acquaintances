using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{

    public static DialogueBox dialogueBox;

    public TextMeshProUGUI textField;


    public DialogueEvent OnFinalize;
    public delegate void DialogueEvent();


    public void Start()
    {

        if(dialogueBox != null)
        {
            Destroy(gameObject);
            return;
        }

        dialogueBox = this;

    }

    public void Init(string text, Vector3 position)
    {

        StopAllCoroutines();

        transform.position = Camera.main.WorldToScreenPoint(position);


        StartCoroutine(Type(text));

    }


    public IEnumerator Type(string text)
    {

        textField.text = "";

        foreach(char c in text.ToCharArray())
        {
            textField.text += c;

            yield return new WaitForSeconds(0.05f);
        }

        OnFinalize?.Invoke();

    }


}
