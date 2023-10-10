using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle State", menuName = "ScriptableObject/FSM State/Idle", order = 4)]
public class MonsterIdleState : ScriptableObject, IState
{
    public void Enter(Monster owner)
    {
        Debug.Log("Idle State Enter");
    }
    public void Excute(Monster owner)
    {
        Debug.Log("Idle Excute");
        
    }
    public void Exit(Monster owner)
    {

    }

}
