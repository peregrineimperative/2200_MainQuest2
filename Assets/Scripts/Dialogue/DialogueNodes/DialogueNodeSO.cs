using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DialogueNodeSO", menuName = "DialogueNode")]
public class DialogueNodeSO : ScriptableObject
{
    
    public CharacterSO speaker;
    [TextArea(2, 5)] 
    public string[] dialogueText;
    public List<DialogueChoice> choices = new();
}

[System.Serializable]
public class DialogueChoice{
    [Header("UI")]
    [TextArea(2, 5)] 
    public string choiceText;
    
    [Header("Flow")]
    public DialogueNodeSO destinationNode;
    public bool endDialogue = false;
    
    [Header("Choice Conditions")]
    public List<QuestFlagSO> requiredQuestFlags = new();
    public List<QuestFlagSO> forbiddenQuestFlags = new();

    [Header("Choice Rewards")]
    public List<QuestFlagSO> grantFlags = new();
}

