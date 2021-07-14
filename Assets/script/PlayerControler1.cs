using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerControler1 : MonoBehaviour
{
    [SerializeField] float m_Speed;
    Rigidbody2D m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");  
        float v = Input.GetAxisRaw("Vertical");     
        Vector2 dir = new Vector2(h, v).normalized; 
        m_rb.velocity = dir * m_Speed;
        this.transform.up = dir;
        
    }
}
