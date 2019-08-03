using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    //[SerializeField] Text nameText;
    [SerializeField] Text dialogueText;
    [SerializeField] float normalTypingSpeed;
    [SerializeField] float startTypingSpeed;

    public Queue<string> sentences;

    /*
    [SerializeField] Text buttonText;
    [SerializeField] Animator dialogueBoxAnimator;
    

    [SerializeField] GameObject comunicatorIcon;
    [SerializeField] GameObject taylorIcon;
    [SerializeField] GameObject richardIcon;
    */

    //public Queue<string> sentences;
    //public Queue<string> sentences;

    public static bool OnDialogue;

    bool useDialogueBox;
    bool jumpTyping;
    bool upgradeOpened;

    //Keep track of all of the sentences
    

    Animator myAnimator;

    float typingSpeed;

    bool finishTyping;

    // Start is called before the first frame update
    void Start()
    {
        useDialogueBox = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && OnDialogue && finishTyping) { DisplayNextSentence(); }
        else if (Input.GetKeyDown(KeyCode.Return) && OnDialogue && !finishTyping) { jumpTyping = true; }
    }

    //funcionamento que pede um "Dialogue"
    public void StartDialogue(Dialogue dialogue)
    {
        OnDialogue = true;
        //comunicatorIcon.SetActive(false);
        //richardIcon.SetActive(false);
        //taylorIcon.SetActive(false);

        //if (useDialogueBox) { dialogueBoxAnimator.SetBool("isOpen", true); nameText.text = dialogue.name; }
        //if (nameText.text == "Taylor") { taylorIcon.SetActive(true); }
        //else if (nameText.text == "Richard") { richardIcon.SetActive(true); }

        //Clear past sentences;
        Debug.Log("right before");
        sentences.Clear();
        Debug.Log("right after");

        //access all strings
        //obs: sentence é um parametro criado
        foreach (string sentence in dialogue.sentences)
        {
            //colocar uma sentence na fila
            sentences.Enqueue(sentence);
        }
        /*if(sentences.Count == 0) { buttonText.text = "close"; }
        else { buttonText.text = "continue>>"; }*/
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        finishTyping = false;
        jumpTyping = false;
        //se nao tiver mais sentenças na fila, terminar e sair da função;
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence);
    }

    IEnumerator TypeSentence(string sentence)
    {
        typingSpeed = normalTypingSpeed;
        //é igual a uma empty string;
        if (useDialogueBox) { dialogueText.text = ""; }

        //para cada char letra(parametro criado) dentro da Lista de letras da sentença 
        //(função transforma string em array de char)
        foreach (char letter in sentence.ToCharArray())
        {
            if (useDialogueBox) { dialogueText.text += letter; }
            //if (!useDialogueBox) { yield return null; }
            if (jumpTyping && useDialogueBox) { dialogueText.text = sentence; finishTyping = true; }
            yield return new WaitForSeconds(typingSpeed); //}
        }
        finishTyping = true;
        jumpTyping = false;
    }

    void EndDialogue()
    {
        Debug.Log("End dialogue!");
        //dialogueBoxAnimator.SetBool("isOpen", false);
        OnDialogue = false;
        useDialogueBox = true;
        finishTyping = false;
        jumpTyping = false;
    }
}
