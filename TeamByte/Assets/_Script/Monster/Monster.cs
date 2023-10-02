using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterData m_sData;
    private MonsterFSM m_cFSM;
    private StateData m_cState;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        m_sData = new MonsterData();

    }
    private IEnumerator OnUpdate()
    {

        while (true)
        {
            if (!m_cFSM)
            {
                m_cFSM.Update();
            }
            yield return new WaitForSeconds(0.04f);
        }
    }
    public bool SetData(StateData _data)            //제일 초기에 한번 데이터 세팅
    {
        m_cState = _data;
        Debug.Log(m_cState);
        if (null == m_cFSM)
        {
            m_cFSM = new MonsterFSM(this);

            Debug.Log(m_cFSM);
        }

        if (!m_cFSM.SetCurrState(m_cState.IdleState))
        {
            Debug.Log("stateData 가 null");
            return false;
        }
        gameObject.SetActive(true);

        StartCoroutine(OnUpdate());
        return true;

    }
}
