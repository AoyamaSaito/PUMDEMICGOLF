using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class StageIn : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCameraBase m_zombiCam = default;
    [SerializeField] CinemachineVirtualCameraBase m_billCam = default;
    [SerializeField] string loadScene;
    Animator FadeAnim;
    void Start()
    {
        GameObject gameObject = GameObject.Find("Fade");
        FadeAnim = gameObject.GetComponent<Animator>();
        SwitchZombiCam();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "StageIn")
        {
            Debug.Log("StageIn");
            m_billCam.Priority = 11;
            StartCoroutine(InStage());
        }
    }

    private void SwitchZombiCam()
    {
        if (m_zombiCam)
        {
            m_zombiCam.Priority = 10;
        }
    }

    IEnumerator InStage()
    {
        yield return new WaitForSeconds(4f);
        FadeAnim.Play("FadeAnim");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(loadScene);
    }

}
