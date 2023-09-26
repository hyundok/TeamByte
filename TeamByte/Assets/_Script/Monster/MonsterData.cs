using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData : MonoBehaviour
{
    public int m_iAttackDamage;
    public int m_iHP;
    public int m_iSpeed;
    public MonsterData()
    {
        m_iAttackDamage = 1;
        m_iHP = 1;
        m_iSpeed = 1;
    }

}
