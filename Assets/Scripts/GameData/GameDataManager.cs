using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance { get; private set; }
    
    [SerializeField] private CharacterDatabaseSO characterDatabase;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //InitializeCharacterData();
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
