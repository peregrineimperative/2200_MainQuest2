using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Scriptable Objects/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public string characterRole;
    public string characterName;
    
    public DialogueNodeSO introDialogueNode;
    public DialogueNodeSO defaultStartingDialogueNode;
}
