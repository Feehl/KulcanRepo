using UnityEngine;
using System;

public class GameManager : StaticInstance<GameManager>
{
    public static event Action<GameState> OnBeforeChanged;
    public static event Action<GameState> OnAfterChanged;

    public GameState State { get; private set; }

    void Start() => ChangeState(GameState.Starting);

    public void ChangeState(GameState newState)
    {
        OnBeforeChanged?.Invoke(newState);

        State = newState;
        switch (newState)
        {
            case GameState.Starting:
                HandleStarting();
                break;
            

            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    private void HandleStarting()
    {

        //ChangeState(GameState);
    }
}



[Serializable]
public enum GameState
{
    Starting = 0,

}
