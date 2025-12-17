using UnityEngine;

[CreateAssetMenu(fileName = "GameStateSO", menuName = "GameState SO")]
public class GameStateSO : ScriptableObject
{
    [SerializeField] public Canvas stateCanvas;
}
