using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    Animator m_anime;
    Animator m_bottunAnim;

    void Start()
    {
        GameObject door = GameObject.Find("door");
        m_anime = door.GetComponent<Animator>();
        m_bottunAnim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        m_anime.Play("VibrationAnime");
        m_bottunAnim.Play("BottunAnim");
    }
}
