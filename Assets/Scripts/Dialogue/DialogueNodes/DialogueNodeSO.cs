using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DialogueNodeSO", menuName = "Scriptable Objects/DialogueNodeSO")]
public class DialogueNodeSO : ScriptableObject
{
    public int NodeID;
    public CharacterSO speaker;
    public string promptText;
    public string[] dialogueText;
    public List<DialogueNodeSO> nextNodes;
}
