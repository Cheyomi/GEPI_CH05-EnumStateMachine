using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public enum GameState
    {
        None,
        Init,
        MainMenu,
        Gameplay,
        Paused,
    }

    // Properties to get the current state and previous game states
    public GameState currentState { get; private set; }

    public GameState previousState { get; private set; }

    [Header("Debug (read only)")]
    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;

    void Start()
    {
        // set the default initial state

        SetState(GameState.Init);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetState(GameState.MainMenu);
        }
    }
    public void SetState(GameState newState)
    {
        if (currentState == newState) return;
        //outside classes can use this to set the gamestate
        previousState = currentState;
        currentState = newState;

        //Update debug strings
        previousActiveState = previousState.ToString();
        currentActiveState = currentState.ToString();

        //tell the gamestate manager to process whatever needs to happen when the gamestat changes
        OnGameStateChanged(previousState, currentState);
    }

    private void OnGameStateChanged(GameState previosState, GameState newState)
    {
        switch (newState)
        {
            case GameState.None:
                Debug.Log("GameState changed to none");
                //do none stuff
                break;

            case GameState.Init:
                //do init stuff
                break;

            case GameState.MainMenu:
                Debug.Log("GameState changed to Main Menu.");
                //do main menu stuff
                break;

            case GameState.Gameplay:
                Debug.Log("GameState changed to Gameplay.");
                //Turn off main menu UI

                // Turn on gameplay UI
                break;

            case GameState.Paused:
                Debug.Log("GameState changed to Paused.");
                //do paused stuff
                break;

            default:
                break; //default
        }
    }
}
