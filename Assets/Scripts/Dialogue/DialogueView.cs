using UnityEngine;
using TMPro;
using System;

public class DialogueView : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI nameText;
    
    [SerializeField] private Transform promptButtonParent;
    
    private ButtonPool<ButtonView> promptButtonPool;
    
    public event Action<DialogueNodeSO> OnPromptButtonClicked;
    
    public void RefreshDialogueVisuals(DialogueNodeSO dialogueNode)
    {
        
    }

    private void SetPromptButtons()
    {
        
    }
}
