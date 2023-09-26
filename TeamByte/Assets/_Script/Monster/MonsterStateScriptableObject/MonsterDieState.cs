using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Die State", menuName = "ScriptableObject/FSM State/Die", order = 3)]
public class MonsterDieState : ScriptableObject, IState
{
    public void Enter(Monster owner)
    {
        Debug.Log("Die State Enter");
    }
    public void Excute(Monster owner)
    {
        Debug.Log("Excute");

    }
    public void Exit(Monster owner)
    {

    }
}
