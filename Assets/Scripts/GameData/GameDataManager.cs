using UnityEngine;
using System.Collections.Generic;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance { get; private set; } //Singleton
    
    [SerializeField] private CharacterDatabaseSO characterDatabase;
    
    public CharacterData characterData = new CharacterData();
    
    private void Awake()
    {
        //Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeCharacterData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeCharacterData()
    {
        //GameData savedData = SaveSystem.TryLoad();
    }
}

//Runtime character information
[System.Serializable]
public class CharacterData
{
    //public string characterName;
    //public int friendScore;
    public HashSet<CharacterSO> CharactersMet;
}
