using System;
using System.Collections.Generic;

public interface IGameStateMachine
{
    public void Construct(List<IState> bindedStates);

    void Enter<TState>();
}