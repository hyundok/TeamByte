using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterData m_sData;
    private MonsterFSM m_cFSM;
    private StateData m_cState;
    [SerializeField] private GameObject m_target;
    public GameObject _target => m_target;
    NavMeshAgent agent;
    void Start()
    {
        transform.position = new Vector3(10, 10, 0);
        m_target = GameObject.Find("Player");
        
        m_cFSM.ChangeState(m_cState.MoveState);
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
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
    public bool SetData(StateData _data)            //���� �ʱ⿡ �ѹ� ������ ����
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
            Debug.Log("stateData �� null");
            return false;
        }
        gameObject.SetActive(true);

        StartCoroutine(OnUpdate());
        return true;

    }
    public void MoveToPlayer()
    {
        agent.SetDestination(m_target.transform.position);
        /*Vector2 direction = m_target.transform.position - transform.position;
        direction.Normalize();

        float moveSpeed = m_sData.m_iSpeed; // �̵� �ӵ�
        transform.Translate(direction * moveSpeed * Time.deltaTime);*/

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("OnTriggerEnter11");
            m_cFSM.ChangeState(m_cState.AttackState);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("s");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("s1");
            m_cFSM.ChangeState(m_cState.AttackState);
        }
    }
}
