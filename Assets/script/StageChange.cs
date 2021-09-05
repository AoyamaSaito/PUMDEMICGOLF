using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StageChange : MonoBehaviour
{
    [SerializeField] string loadScene;
    Animator FadeAnim;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = GameObject.Find("Fade");
        FadeAnim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "StageIn")
        {
            Debug.Log("StageIn");
            StartCoroutine(InStage());
        }
    }
    IEnumerator InStage()
    {
        yield return new WaitForSeconds(0.1f);
        FadeAnim.Play("FadeAnim");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(loadScene);
    }

    public void StageStart()
    {
        StartCoroutine(InStage());
    }
}
