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
    
    [Header("State Canvases")]
    [SerializeField] private Canvas navigationCanvas;
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private Canvas computerCanvas;
    [SerializeField] private Canvas pauseMenuCanvas;


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

    private void Start()
    {
        //Inelegant, but whatever
        //Jump straight to opening dialogue
        StartNewGame();
    }
    
    //terrible if-statement town
    private Canvas GetCanvasForState(GameStateSO state)
    {
        if (state == navigationState) return navigationCanvas;
        if (state == dialogueState)   return dialogueCanvas;
        if (state == computerState)   return computerCanvas;
        if (state == pauseMenuState)  return pauseMenuCanvas;
        return null;
    }
    
    //Accessor for current game state
    public GameStateSO CurrentState => GameStateStack.Peek();
    
    //Call when moving to a new state (opening a new window, basically)
    public void EnterState(GameStateSO newState)
    {
        var currentCanvas = GetCanvasForState(CurrentState);
        PauseCanvas(currentCanvas);
        GameStateStack.Push(newState);
        
        var newCanvas = GetCanvasForState(newState);
        newCanvas.gameObject.SetActive(true);
        ResumeCanvas(newCanvas);
    }
    
    //Call when leaving a state entirely (a window is being closed)
    public void ExitState()
    {
        var currentCanvas = GetCanvasForState(CurrentState);
        currentCanvas.gameObject.SetActive(false);
        GameStateStack.Pop();
        
        var newCanvas = GetCanvasForState(CurrentState);
        ResumeCanvas(newCanvas);
    }

    //Call when moving to a new state without closing the current one.
    private void PauseCanvas(Canvas canvas)
    {
        var group = canvas.GetComponent<CanvasGroup>();
        if (group == null) return;
        group.alpha = .5f;
        group.interactable = false;
    }
    
    //Call to activate a previous window when it becomes the top state in the stack.
    private void ResumeCanvas(Canvas canvas)
    {
        var group = canvas.GetComponent<CanvasGroup>();
        if (group == null) return;
        group.alpha = 1f;
        group.interactable = true;
    }


    private void StartNewGame()
    {
        //debugging
        if (DialogueState == null)
        {
            Debug.LogError("DialogueState is not assigned on GameStateController.");
            return;
        }
        
        EnterState(DialogueState);
        
        //debugging
        if (DialogueController.Instance == null)
        {
            Debug.LogError("DialogueController.Instance is null.");
            return;
        }

        if (openingCharacter == null)
        {
            Debug.LogError("Opening character is not assigned on GameStateController.");
            return;
        }

        DialogueController.Instance.StartNewDialogue(openingCharacter);
    }
}
