using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class siminclear : MonoBehaviour
{
    Animator FadeAnim;
    Animator Elevator1;
    Animator Elevator2;
    [SerializeField] GameObject gameObject1;
    GameObject gameObject3;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = GameObject.Find("Fade");
        FadeAnim = gameObject.GetComponent<Animator>();
        GameObject gameObject1 = GameObject.Find("Deguchi1");
        Elevator1 = gameObject1.GetComponent<Animator>();
        GameObject gameObject2 = GameObject.Find("Deguchi2");
        Elevator2 = gameObject2.GetComponent<Animator>();
        gameObject3 = GameObject.Find("hijoguchi");
        gameObject3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Fade");
            if (FadeAnim)
            {
            FadeAnim.Play("FadeAnim");
            Debug.Log("FadeAnim");
            }
        StartCoroutine(ChangeSprite());
    }
    IEnumerator ChangeSprite()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(gameObject1, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Elevator1.Play("deguchiElevator");
        Elevator2.Play("deguchiElevator2");
        gameObject3.SetActive(true);
    }
}
