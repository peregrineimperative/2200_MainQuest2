using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DialogueNodeSO", menuName = "Scriptable Objects/DialogueNodeSO")]
public class DialogueNodeSO : ScriptableObject
{
    
    public CharacterSO speaker;
    
    public string[] dialogueText;
    public List<DialogueChoice> Choices = new();
}

[System.Serializable]
public class DialogueChoice{
    [Header("UI")]
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

