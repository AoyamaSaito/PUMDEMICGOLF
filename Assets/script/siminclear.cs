using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class siminclear : MonoBehaviour
{
    Animator FadeAnim;
    [SerializeField] GameObject gameObject1;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = GameObject.Find("Fade");
        FadeAnim = gameObject.GetComponent<Animator>();
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
    }
}
