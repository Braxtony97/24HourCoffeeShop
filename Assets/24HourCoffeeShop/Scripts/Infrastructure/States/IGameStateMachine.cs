using System;
using System.Collections.Generic;

public interface IGameStateMachine
{
    void Enter<TState>();
}