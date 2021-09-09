using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    GameObject pausePanel;

    void Start()
    {
        pausePanel = GameObject.Find("PausePanel");
        pausePanel.SetActive(false);
    }

    public void Pause()
    {
        if (Input.GetKeyDown("Cancel"))
        {
            pausePanel.SetActive(true);
        }
    }
}
