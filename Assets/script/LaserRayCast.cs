using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserRayCast : MonoBehaviour
{
    Vector2 distance = Vector2.zero;
    [SerializeField] LayerMask m_PlayerLayer = 0;
    [SerializeField] LayerMask m_WallLayer = 0;
    [SerializeField] LayerMask m_castLayer = 0;
    [SerializeField] GameObject shitai;
    float kyori;
    PatrolEnemy pe;
    PlayerController2D PC2D;
    Transform tf;
    GameObject gameObject1;
    [SerializeField] UnityEvent UE;
    [SerializeField] UnityEvent UE2;
    bool stopLay = true;
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
        if (stopLay)
        {
            RaycastHit2D hit;
            Vector2 start = this.transform.position;
            Vector2 end = this.transform.position + this.transform.up * 100;
            hit = Physics2D.Linecast(start, end, m_castLayer);
            Debug.DrawLine(start, end);
            if (hit)
            {
                Debug.Log($"{hit.collider.name} に当たった");
            }

            if (hit.collider.name == "Player")
            {
                UE.Invoke();
                Instantiate(shitai, tf.transform.position, Quaternion.identity);
                Destroy(gameObject1);
                StartCoroutine(SecondsCourutine());
                Debug.Log("hit");
            }
        }
        else StopLay(); 
        

    }

    IEnumerator SecondsCourutine()
    {
        yield return new WaitForSeconds(1f);
        UE2.Invoke();
        Debug.Log("courutine");
    }

    public void StopLay()
    {
        stopLay = false;
    }
}
