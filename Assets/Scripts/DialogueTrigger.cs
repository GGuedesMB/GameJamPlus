using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    /*
    [SerializeField] bool nameSpoken;

    [SerializeField] bool cutscene0;
    [SerializeField] bool cutscene1;
    [SerializeField] bool cutscene2;
    [SerializeField] bool cutscene3;
    [SerializeField] bool cutscene2_0; 
    */
    //Here we create where the dialogue will be stored ready to start;
    [SerializeField] Dialogue[] dialogue;
    /*
    [SerializeField] Dialogue dialoguePart2;
    [SerializeField] Dialogue dialogueStatic;
    [SerializeField] Dialogue dialogueStatic1_5;
    [SerializeField] Dialogue dialogueStaticRic;
    */

    //CameraController cameraController;
    //Som som;
    DialogueSystem ds;

    float activations;

    float timer;

    bool turnOffLight;

    private void Start()
    {
        ds = GetComponent<DialogueSystem>();
        /*som = FindObjectOfType<Som>();
        comunicator = GetComponent<CapsuleCollider2D>();
        area = GetComponent<BoxCollider2D>();
        cameraController = FindObjectOfType<CameraController>();
        if (nameSpoken && cutscene2)
        {
            dialogue.sentences[0] = "SOCORRO!!! SOCORRO!!!";
            dialogue.sentences[1] = "Porque os bons morrem tão cedo?";
            dialoguePart2.sentences[0] = "Você me salvou!!! Nem sei como te agradecer… Como se chama a pessoa que salvou minha vida?";
            dialoguePart2.sentences[1] = GameGlobalInfo.playerName + 
                ", eu te devo tanto… Por hora, você pode ficar com a minha mais nova invenção!";
            dialoguePart2.sentences[2] = "Com essas botas, você poderá pular enquanto está no ar.";
            dialoguePart2.sentences[3] = "É bom ter mais de nós por aqui… Espero te encontrar novamente.";
        }
        else if (nameSpoken && cutscene3)
        {
            dialogue.sentences[0] = "Obrigada, " + GameGlobalInfo.playerName + ". É bom finalmente te conhecer pessoalmente.";
            dialoguePart2.sentences[4] = GameGlobalInfo.playerName + ", CUIDADO!!!"; 
        }
        else if (nameSpoken && cutscene2_0)
        {
            dialogue.sentences[0] = GameGlobalInfo.playerName + " ... está me escut...";
        }
        if (cutscene2_0) { Invoke("f2D0",4); }

        */
    }

    private void Update()
    {

        /*if (cameraController.cameraIndex == 2 && activations > 0 && Input.GetKeyDown(KeyCode.E) && 
            !DialogueManager.OnDialogue &&
         comunicator.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            TriggerDialogue(dialogueStatic);
        }
        else if (cameraController.cameraIndex == 7 && activations > 0 && Input.GetKeyDown(KeyCode.E) &&
            !DialogueManager.OnDialogue &&
         comunicator.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            TriggerDialogue(dialogueStatic1_5);
        }
        else if (activations > 0 && Input.GetKeyDown(KeyCode.E) && !DialogueManager.OnDialogue && 
            comunicator.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            TriggerDialogue(dialogueStaticRic);
        }
     
        //if (turnOffLight) { lightSpot.intensity *= 0.99f; }
        */
    }

    public void DTrigger(int dialogueIndex)
    {
        Debug.Log(dialogue[dialogueIndex].sentences[0]);
        //TriggerDialogue(dialogue[dialogueIndex]);
        ds.StartDialogue(dialogue[dialogueIndex]);
    }

    private void f2D0()
    {
        //TriggerDialogue(dialogue);
        //som.Int_Radio(FindObjectOfType<Player>().transform.position);
    }

    public void Dialogue0Activation()
    {
        //TriggerDialogue(dialogue);
        
    }

    public void Dialogue0Part2Activation()
    {
        //TriggerDialogue(dialoguePart2);
        //som.Int_Radio(FindObjectOfType<Player>().transform.position);
    }

    public void Dialogue2Activation()
    {
        Debug.Log("AQUIAQUI");
        //TriggerDialogue(dialogue);
        //som.Int_Radio(FindObjectOfType<Player>().transform.position);
    }

    public void Dialogue2Part2Activation()
    {
        Debug.Log("AQUIAQUI");
        //TriggerDialogue(dialoguePart2);
    }

    public void Dialogue3Activation()
    {
        //TriggerDialogue(dialogue);
    }

    public void Dialogue3Part2Activation()
    {
        //TriggerDialogue(dialoguePart2);
    }

    //Função para pegar o funcionamento do dialogo
    public void TriggerDialogue(Dialogue currentDialogue)
    {
        Debug.Log("Before get on DSystem");
        FindObjectOfType<DialogueSystem>().StartDialogue(currentDialogue);
        activations++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player>() != null && activations == 0)
        {
            //TriggerDialogue(dialogue);
            //area.enabled = false;
            //if (cutscene1) { som.Int_Radio(FindObjectOfType<Player>().transform.position); }
        }
    }
}
