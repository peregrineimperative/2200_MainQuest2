using System;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    private DialogueNodeSO CurrentDialogueNode { get; set; }

    private CharacterSO CurrentSpeaker { get; set; }
    
    //[SerializeField] private DialogueNodeSO startingDialogueNode;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private TextMeshProUGUI nameText;

    private void OnEnable()
    {
        StartNewDialogue(CurrentSpeaker);
    }

    private void StartNewDialogue(CharacterSO speaker)
    {
        CurrentSpeaker = speaker;
    }

    private DialogueNodeSO DetermineStartingDialogueNode()
    {
        //1. Look through list of active quest steps to see if one involves this character
        //If so, start from that step's associated dialogue node
        
        //2. Else, check if friendship score is above 0 (unmet if zero)
        //If not, use character's introductory dialogue node
        
        //3. Else, use character's default dialogue node
    }
    
    
    private DialogueNodeSO GetNextDialogueNode(CharacterSO speaker)
    {
        
    }
    
    

    private void UpdateVisual()
    {
        //delete old buttons
        
        //create new buttons
        
        dialogueText.text = CurrentDialogueNode.dialogueText[0];
        //promptText.text = CurrentDialogueNode.nextNodes[0].promptText;
        nameText.text = CurrentDialogueNode.speaker.characterName;
    }

    public void OnPromptClicked()
    {
        CurrentDialogueNode = CurrentDialogueNode.nextNodes[0];
        UpdateVisual();
    }
}
