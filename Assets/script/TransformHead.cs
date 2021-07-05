using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHead : MonoBehaviour
{
    Rigidbody2D m_rb;
    public float torque;
    [SerializeField]float turn = 0;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.AddTorque(turn * torque );
    }
}
