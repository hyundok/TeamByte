using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;
using static UnityEngine.GraphicsBuffer;


public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterData m_sData;
    private MonsterFSM m_cFSM;
    private StateData m_cState;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        m_sData = new MonsterData();
        Debug.Log("Update");
        StartCoroutine(OnUpdate());
    }
    private IEnumerator OnUpdate()
    {
        Debug.Log(m_cFSM);
        while (true)
        {
            if(!m_cFSM)
                m_cFSM.Update();

            yield return new WaitForSeconds(0.04f);
        }
    }
    public bool SetData(StateData _data)            //제일 초기에 한번 데이터 세팅
    {
        m_cState = _data;
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

        return true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
