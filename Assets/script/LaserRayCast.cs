using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRayCast : MonoBehaviour
{
    [SerializeField] Vector2 distance = Vector2.zero;
    [SerializeField] LayerMask m_PlayerLayer = 0;
    [SerializeField] LayerMask m_WallLayer = 0;
    [SerializeField] float m_ray = 20;
    float kyori;
    PatrolEnemy pe;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        pe = GetComponent<PatrolEnemy>();

        Vector2 m_Ray = pe.dir * 50;
        Vector2 origin = this.transform.localPosition;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, m_Ray, m_ray, m_WallLayer);
        if(hit.collider)
        {
            kyori = hit.distance;
            Debug.Log(hit.point);
            Debug.Log(kyori);

            Vector2 Ray = hit.point;
            Debug.DrawLine(origin, Ray);
            RaycastHit2D hit2 = Physics2D.Raycast(this.transform.position, Ray, kyori, m_PlayerLayer);
            if (hit2.collider)
            {

                Debug.Log("hit");
            }
        }
        //Vector2 Ray = hit.point ;
        //Debug.DrawLine(origin, Ray);
        //RaycastHit2D hit2 = Physics2D.Raycast(this.transform.position, Ray,kyori , m_PlayerLayer);
        //if (hit2.collider)
        //{

        //    Debug.Log("hit");
        //}
    }
}
