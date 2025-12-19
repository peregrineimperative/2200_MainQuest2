using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Maintains/keeps track of the current game state via a stack.
/// New game states are entered and pushed onto the stack, and when exited, the game returns to the previous state.
/// </summary>
public class GameStateController : MonoBehaviour
{
    //Singleton pattern
    public static GameStateController Instance { get; private set; }
    
    //Current state of the game.
    private Stack<GameStateSO> GameStateStack { get; set; }
    
    //References to possible states in the game
    [Header("States")]
    //[SerializeField] private GameStateSO MainMenuState;
    [SerializeField] private GameStateSO navigationState;
    [SerializeField] private GameStateSO dialogueState;
    [SerializeField] private GameStateSO computerState;
    [SerializeField] private GameStateSO pauseMenuState;
    
    public GameStateSO NavigationState => navigationState;
    public GameStateSO DialogueState => dialogueState;
    public GameStateSO ComputerState => computerState;
    public GameStateSO PauseMenuState => pauseMenuState;

    [Header("New Game Information")] 
    [SerializeField] private CharacterSO openingCharacter;
    
    private void Awake()
    {
        //Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
        
        //Initialize the stack
        GameStateStack = new Stack<GameStateSO>();
        GameStateStack.Push(NavigationState); //Set this to whatever should be the default game state. (Currently Navigation, but if I am cool and implement a MainMenu, then do that instead.)
    }

    //Accessor for current game state
    public GameStateSO CurrentState => GameStateStack.Peek();
    
    //Call when moving to a new state (opening a new window, basically)
    public void EnterState(GameStateSO newState)
    {
        PauseState();
        GameStateStack.Push(newState);
        CurrentState.stateCanvas.gameObject.SetActive(true);
    }
    
    //Call when leaving a state entirely (a window is being closed)
    public void ExitState()
    {
        CurrentState.stateCanvas.gameObject.SetActive(false);
        GameStateStack.Pop();
        ResumeState();
    }

    //Call when moving to a new state without closing the current one.
    private void PauseState()
    {
        CurrentState.stateCanvas.GetComponent<CanvasGroup>().alpha = 0.5f;
        CurrentState.stateCanvas.GetComponent<CanvasGroup>().interactable = false;
    }
    
    //Call to activate a previous window when it becomes the top state in the stack.
    private void ResumeState()
    {
        CurrentState.stateCanvas.GetComponent<CanvasGroup>().alpha = 1f;
        CurrentState.stateCanvas.GetComponent<CanvasGroup>().interactable = true;
    }

    private void StartNewGame()
    {
        DialogueController.Instance.StartNewDialogue(openingCharacter);
        EnterState(DialogueState);
    }
}
