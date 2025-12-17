using System;
using UnityEngine;
using System.Collections.Generic;

public class GameStateController : MonoBehaviour
{
    //Current state of the game.
    private Stack<GameStateSO> GameStateStack { get; set; }
    
    //References to possible states in the game
    [Header("States")]
    //[SerializeField] private GameStateSO MainMenuState;
    [SerializeField] private GameStateSO NavigationState;
    [SerializeField] private GameStateSO DialogueState;
    [SerializeField] private GameStateSO ComputerState;
    [SerializeField] private GameStateSO PauseMenuState;
    
    private void Awake()
    {
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
    
}
