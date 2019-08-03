using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{
    public static int narrativePoint;

    [Header("References")]
    [SerializeField] GameObject startPanel;
    [SerializeField] Player player;
    //[SerializeField] DialogueTrigger dialogueTrigger;
    [SerializeField] Text narrativePointsText;
    [SerializeField] DialogueSystem ds;

    [Header("References")]
    [SerializeField] Dialogue dialogue;

    //DialogueSystem ds;

    int[] dialogueNarrativePoints = {1,3};

    // Start is called before the first frame update
    void Start()
    {
        ds = FindObjectOfType<DialogueSystem>();
        narrativePoint = 0;
        startPanel.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //For testing reasons...
        narrativePointsText.text = "Narrative Progress: " + narrativePoint.ToString();

        NarrativeFlow();
        
        if (narrativePoint == 1) { startPanel.gameObject.SetActive(false); }
        if (narrativePoint == 2) { player.gameObject.SetActive(true); }
        if (narrativePoint >= 3) { player.Move(); }
        if (narrativePoint >= 4) { player.Jump(); }
    }

    void NarrativeFlow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            narrativePoint++;
            for (int i = 0; i < dialogueNarrativePoints.Length; i++)
            {
                if (narrativePoint == dialogueNarrativePoints[i])
                {
                    Debug.Log("Understand when to activate");
                    ds.StartDialogue(dialogue);
                }
                
            }
        }
    }

}
