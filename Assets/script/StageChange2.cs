﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StageChange2 : MonoBehaviour
{
    [SerializeField] string loadScene;
    Animator FadeAnim;
    new GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.Find("Panel");
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
        yield return new WaitForEndOfFrame();
        gameObject.transform.SetAsLastSibling();
        yield return new WaitForSeconds(0.1f);
        FadeAnim.Play("FadePanelAnim");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(loadScene);
    }

    public void StageStart()
    {
        StartCoroutine(InStage());
        Debug.Log("押された");
    }
}
