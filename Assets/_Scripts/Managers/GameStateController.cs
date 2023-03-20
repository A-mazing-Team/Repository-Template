using UnityEngine;
using System;

public enum GameState
{
    Menu, Playing, ReviveCooldown, Win, Lose
}

public class GameStateController : MonoBehaviour
{
    public event Action<GameState> OnStateChangedEvent;
    public event Action OnMenuStateEvent;
    public event Action OnGameStartedEvent;
    public event Action OnGameEndedEvent;
    public event Action OnWinEvent;
    public event Action OnLoseEvent;

    [SerializeField] private GameState _state;

    public bool IsPlaying { get; private set; }
    public GameState State
    {
        get => _state;
        set
        {
            if (value == _state) return;

            _state = value;

            switch(value)
            {
                case GameState.Menu:
                    SetMenuState();
                    break;

                case GameState.Playing:
                    TryStartGame();
                    break;
                
                case GameState.ReviveCooldown:
                    StartReviveCooldown();
                    break;

                case GameState.Win:
                    TryWin();
                    break;

                case GameState.Lose:
                    TryLose();
                    break;
            }

            OnStateChangedEvent?.Invoke(_state);
        }
    }


    private void Start()
    {
        State = _state;
    }

    private void SetMenuState()
    {
        IsPlaying = false;
        OnMenuStateEvent?.Invoke();
    }

    private void TryStartGame()
    {
        if (IsPlaying) return;

        IsPlaying = true;
        OnGameStartedEvent?.Invoke();
    }

    private void StartReviveCooldown()
    {

    }

    private void TryWin()
    {
        if (IsPlaying == false) return;
        EndGame();

        OnWinEvent?.Invoke();
    }


    private void TryLose()
    {
        if (IsPlaying == false) return;
        EndGame();

        OnLoseEvent?.Invoke();
    }

    private void EndGame()
    {
        IsPlaying = false;
        OnGameEndedEvent?.Invoke();
    }
}