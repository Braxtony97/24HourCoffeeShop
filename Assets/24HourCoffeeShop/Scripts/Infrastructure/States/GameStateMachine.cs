using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using Zenject;

public class GameStateMachine : IGameStateMachine  
{
    private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
    private IState _currentState;

    [Inject]
    public void Construct(List<IState> bindedStates)
    {
        foreach (IState state in bindedStates)
        {
            Type stateType = state.GetType();

            if (!_states.ContainsKey(stateType)) // TODO
            {
                _states[stateType] = state;
            }
        }
    }

    public void Enter<TState>()
    {
        IState state = GetState(typeof(TState));
        state.Enter();
    }

    private IState GetState(Type stateType)
    {
        _currentState?.Exit();
        IState state = _states[stateType];
        _currentState = state;
        return state;
    }
}
