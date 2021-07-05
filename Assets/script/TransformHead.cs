using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHead : MonoBehaviour
{
    Rigidbody2D m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.right = m_rb.velocity;
    }
}
