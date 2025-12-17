using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    private DialogueNodeSO CurrentDialogueNode { get; set; }

    [SerializeField] private DialogueNodeSO startingDialogueNode;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private TextMeshProUGUI nameText;

    private void Start()
    {
        CurrentDialogueNode = startingDialogueNode;
        UpdateVisual();
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
