using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    Animator m_anime;

    void Start()
    {
        GameObject point = GameObject.Find("point");
        m_anime = point.GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("REDBUTTON");
        m_anime.Play("VibrationAnime");
    }
}
