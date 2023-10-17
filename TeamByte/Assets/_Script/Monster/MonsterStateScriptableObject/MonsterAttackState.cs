using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack State", menuName = "ScriptableObject/FSM State/Attack", order = 3)]
public class MonsterAttackState : ScriptableObject, IState
{
    public void Enter(Monster owner)
    {
        Debug.Log("Attack State Enter");
    }
    public void Excute(Monster owner)
    {
        Debug.Log("Attack State Execute");
    }
    public void Exit(Monster owner)
    {

    }
}
