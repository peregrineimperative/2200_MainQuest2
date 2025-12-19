using System;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance { get; private set; } //Singleton

    [SerializeField] private DialogueView dialogueView;
    
    private DialogueNodeSO CurrentDialogueNode { get; set; }
    public CharacterSO CurrentSpeaker { get; set; }

    private void Awake()
    {
        //Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    
    private void OnEnable()
    {
        if (dialogueView != null)
        {
            dialogueView.OnPromptButtonClicked += GoToNextNode;
        }
        
        if (CurrentSpeaker != null)
        {
            StartNewDialogue(CurrentSpeaker);
        }

    }
    
    private void OnDisable()
    {
        dialogueView.OnPromptButtonClicked -= GoToNextNode;
    }

    public void StartNewDialogue(CharacterSO speaker)
    {
        if (speaker == null)
        {
            Debug.LogWarning("StartNewDialogue called with null speaker.");
            return;
        }

        CurrentSpeaker = speaker;
        CurrentDialogueNode = DetermineStartingDialogueNode();

        if (CurrentDialogueNode == null)
        {
            Debug.LogWarning($"No starting dialogue node found for {speaker.characterName}");
            return;
        }

        // Tell the view to update itself
        //dialogueView.ShowNode(CurrentSpeaker, CurrentDialogueNode);

    }

    private DialogueNodeSO DetermineStartingDialogueNode()
    {
        //1. Look through list of active quest steps to see if one involves this character
        //If so, start from that step's associated dialogue node
        
        //2. Else, check if character has been met.
        //If not, use character's introductory dialogue node
        if (!GameDataManager.Instance.characterData.HasMet(CurrentSpeaker))
        {
            if (CurrentSpeaker.introDialogueNode != null) return CurrentSpeaker.introDialogueNode;
        }
        
        //3. Else, use character's default dialogue node
        if (CurrentSpeaker.defaultStartingDialogueNode != null) return CurrentSpeaker.defaultStartingDialogueNode;
        
        return null;
    }

    private void GoToNextNode(DialogueNodeSO nextNode)
    {
        //End of dialogue branch
        if (nextNode == null)
        {
            Debug.Log("Dialogue ended or no next node.");
            
            //Mark current speaker as met when dialogue ends
            if (CurrentSpeaker != null && GameDataManager.Instance.characterData != null)
            {
                GameDataManager.Instance.characterData.MarkMet(CurrentSpeaker);
            }
            
            CurrentDialogueNode = null;
            GameStateController.Instance.ExitState();
            return;
        }

        CurrentDialogueNode = nextNode;
        //dialogueView.ShowNode(CurrentSpeaker, CurrentDialogueNode);
    }
}
