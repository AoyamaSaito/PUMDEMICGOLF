using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRay : MonoBehaviour
{
    [SerializeField] Vector2 distance = Vector2.zero;
    [SerializeField] LayerMask m_PlayerLayer = 0;
    [SerializeField] LayerMask m_WallLayer = 0;
    [SerializeField] float m_ray = 20;
    float kyori;
    Rigidbody2D rb;
    PatrolEnemy pe;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
        Vector2 m_Ray = new Vector2(0 , m_ray);
        Vector2 origin = this.transform.position;   
        Debug.DrawLine(origin, origin + m_Ray); 
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, m_Ray, m_ray, m_WallLayer);
        if (hit.collider)
        {
            kyori = hit.distance;
        }

        Vector2 Ray = new Vector2(0, kyori);
        Debug.DrawLine(origin, origin + Ray);
        RaycastHit2D hit2 = Physics2D.Raycast(this.transform.position, Ray, kyori, m_PlayerLayer);
        if (hit2.collider)
        {

        }

    }
}
