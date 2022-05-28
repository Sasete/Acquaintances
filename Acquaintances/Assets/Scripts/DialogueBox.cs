using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{

    public static DialogueBox dialogueBox;

    public TextMeshProUGUI textField;

    public GameObject mesh;

    public List<DialogueEvent> reg = new List<DialogueEvent>();

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
        Hide();

    }

    public void Init(string text, Vector3 position)
    {

        StopAllCoroutines();
        Hide(false);

        transform.position = Camera.main.WorldToScreenPoint(position);


        StartCoroutine(Type(text));

    }

    public void Hide(bool hidden = true) => mesh.SetActive(!hidden);


    public IEnumerator Type(string text)
    {

        textField.text = "";

        foreach(char c in text.ToCharArray())
        {
            textField.text += c;

            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1f);

        Hide();
        // OnFinalize?.Invoke();

        reg.RemoveAt(0);

        if(reg.Count > 0)
            reg[0]?.Invoke();

    }


}
