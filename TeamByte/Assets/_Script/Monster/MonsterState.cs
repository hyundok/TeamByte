using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public interface IState
{
    public void Enter(Monster owner);
    public void Excute(Monster owner);
    public void Exit(Monster owner);
}
public class StateData : ScriptableObject
{
    public IState IdleState { get; private set; }
    public IState MoveState { get; private set; }
    public IState AttackState { get; private set; }
    public IState DieState { get; private set; }
    public void SetData(IState idle, IState move, IState attack, IState die)
    {
        IdleState = idle;
        MoveState = move;
        AttackState = attack;
        DieState = die;
    }

}
