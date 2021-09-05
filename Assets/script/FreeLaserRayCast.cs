using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FreeLaserRayCast : MonoBehaviour
{
    [SerializeField] LayerMask m_castLayer = 0;
    [SerializeField] GameObject shitai;
    Transform tf;
    GameObject gameObject1;
    [SerializeField] UnityEvent UE;
    [SerializeField] UnityEvent UE2;
    bool stopLay = true;
    [SerializeField] int layKyori = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject1 = GameObject.Find("Player");
        tf = gameObject1.GetComponent<Transform>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (stopLay)
        {
            LayCast();
            //if (hit)
            //{
            //    Debug.Log($"{hit.collider.name} に当たった");
            //}
            
        } 
        

    }

    IEnumerator SecondsCourutine()
    {
        yield return new WaitForSeconds(1f);
        UE2.Invoke();
    }

    public void StopLay()
    {
        stopLay = false;
    }

    public void LayCast()
    {
        RaycastHit2D hit;
        Vector2 start = this.transform.position;
        Vector2 end = this.transform.position + this.transform.up * layKyori;
        hit = Physics2D.Linecast(start, end, m_castLayer);
        Debug.DrawLine(start, end);

        if (hit)
        {

            if (hit.collider.name == "Player")
            {
                UE.Invoke();
                Instantiate(shitai, tf.transform.position, Quaternion.identity);
                Destroy(gameObject1);
                StartCoroutine(SecondsCourutine());
            }
        }
    }
}
