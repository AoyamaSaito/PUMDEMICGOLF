using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Transform m_Firstposition;
    [SerializeField] Transform m_zombihead;  
    Text m_ScoreText;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        m_ScoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = m_zombihead.position.x- m_Firstposition.position.x;
        m_ScoreText.text = "キョリ : " + (int)distance;
    }

    private void Timerdayo()
    {
        
    }
}
