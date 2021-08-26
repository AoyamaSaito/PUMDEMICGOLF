using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserRayCast : MonoBehaviour
{
    [SerializeField] Vector2 distance = Vector2.zero;
    [SerializeField] LayerMask m_PlayerLayer = 0;
    [SerializeField] LayerMask m_WallLayer = 0;
    [SerializeField] float m_ray = 20;
    [SerializeField] GameObject shitai;
    float kyori;
    PatrolEnemy pe;
    PlayerController2D PC2D;
    Transform tf;
    GameObject gameObject1;
    [SerializeField] UnityEvent UE;
    [SerializeField] UnityEvent UE2;
    // Start is called before the first frame update
    void Start()
    {
        gameObject1 = GameObject.Find("Player");
        tf = gameObject1.GetComponent<Transform>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        pe = GetComponent<PatrolEnemy>();

        Vector2 m_Ray = pe.dir * 50;
        Vector2 origin = this.transform.localPosition;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, m_Ray, m_ray, m_WallLayer);
        if(hit.collider)
        {
            kyori = hit.distance;
            Vector2 Ray = hit.point;
            Debug.DrawLine(origin, Ray);
            RaycastHit2D hit2 = Physics2D.Raycast(this.transform.position, Ray, kyori, m_PlayerLayer);
            if (hit2.collider)
            {
                UE.Invoke();
                Instantiate(shitai, tf.transform.position, Quaternion.identity);
                Destroy(gameObject1);
                StartCoroutine(SecondsCourutine());
                Debug.Log("hit");
            }
        }


        IEnumerator SecondsCourutine()
        {
            yield return new WaitForSeconds(1f);
            UE2.Invoke();
            Debug.Log("courutine");
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
