using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance { get; private set; }
    public Monster testMon;
    public MonsterData MonData;
    [SerializeField] private List<Monster> m_lMonsterList;
    void Awake()
    {
        if (null == Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);


    }
    public void MonsterInit(Monster monster)
    {
        Debug.Log(monster);
        IState idle = (IState)Resources.Load("ScriptableObject/MonsterState/IdleState");
        IState move = (IState)Resources.Load("ScriptableObject/MonsterState/MoveState");
        IState attack = (IState)Resources.Load("ScriptableObject/MonsterState/AttackState");
        IState die = (IState)Resources.Load("ScriptableObject/MonsterState/DieState");
        StateData data = ScriptableObject.CreateInstance<StateData>();
        data.SetData(idle, move, attack, die);
        Debug.Log(data.ToString());
        testMon.SetData(data);
    }
}
