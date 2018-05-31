using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericState<T> : ScriptableObject
{

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();


    public GenericState<T> Init(T target)
    {
        m_target = target;
        return this;
    }
    protected T m_target;
    
}
