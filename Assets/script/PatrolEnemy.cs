using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] Transform[] m_targets = default;
    [SerializeField] float m_stopDistance = 0.05f;
    [SerializeField] float m_moveSpeed = 0f;

    public Vector3 dir;
    bool stopBool = true;
    int n = 0;
    Rigidbody2D m_rb = default;
    void Start()
    {
         m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(this.transform.position, m_targets[n].position);

        if (stopBool)
        {
            if (distance > m_stopDistance)
            {
                dir = (m_targets[n].transform.position - this.transform.position).normalized * m_moveSpeed;
                m_rb.velocity = dir;
                this.transform.up = dir;
            }
            else
            {

                n = (n + 1) % m_targets.Length;

            }
        }
        else
        {
            m_rb.velocity = Vector2.zero ;
        }
    }
    public void Stop()
    {
        stopBool = false;
    }
}
