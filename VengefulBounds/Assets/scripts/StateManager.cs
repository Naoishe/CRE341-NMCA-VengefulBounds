using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentstate;
    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState= currentstate?.RunCurrentState();

        if(nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        currentstate= nextState;
    }
}
