using UnityEngine;
using TMPro;
using System;

public class DialogueView : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI nameText;
    
    [SerializeField] private Transform promptButtonParent;
    [SerializeField] private GameObject promptButtonPrefab;
    
    private ButtonPool<ButtonView> promptButtonPool;
    
    public event Action<DialogueNodeSO> OnPromptButtonClicked;

    public void Awake()
    {
        promptButtonPool = new ButtonPool<ButtonView>(promptButtonPrefab, promptButtonParent, 6);
    }
    
    public void RefreshDialogueVisuals(DialogueNodeSO dialogueNode)
    {
        if(dialogueNode == null) return;

        if (dialogueNode.speaker != null)
        {
            nameText.text = dialogueNode.speaker.characterName;
            titleText.text = dialogueNode.speaker.characterRole;
        }
        else
        {
            //Don't want to display default text
            nameText.text = "";
            titleText.text = "";
        }
        
        //time permitting, come back to do something with multiple lines of dialogue.
        if(dialogueText != null) dialogueText.text = dialogueNode.dialogueText[0];
        
        SetPromptButtons(dialogueNode);
    }

    private void SetPromptButtons(DialogueNodeSO dialogueNode)
    {
        promptButtonPool.ReleaseAllButtons();

        foreach (DialogueChoice choice in dialogueNode.choices)
        {
            ButtonView button = promptButtonPool.GetButton(promptButtonParent);
            button.ButtonText.text = choice.choiceText;
            button.Button.onClick.AddListener(() => OnPromptButtonClicked?.Invoke(choice.destinationNode));
            button.gameObject.SetActive(true);
        }
        
    }
    
}
