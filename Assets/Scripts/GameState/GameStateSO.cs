using UnityEngine;

[CreateAssetMenu(fileName = "GameStateSO", menuName = "GameState SO")]
public class GameStateSO : ScriptableObject
{
    //having this reference things in the scene was causing problems;
    //[SerializeField] public Canvas stateCanvas;
}
