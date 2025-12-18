using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CharacterDatabaseSO", menuName = "Scriptable Objects/CharacterDatabaseSO")]
public class CharacterDatabaseSO : ScriptableObject
{
    public List<CharacterSO> characters;
}
