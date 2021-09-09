using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    GameObject pausePanel;
    bool m_pauseFlg = false;
    bool onOff = false;

    void Start()
    {
        pausePanel = GameObject.Find("PausePanel");
        pausePanel.SetActive(false);
    }


    void Update()
    {
        // ESC キーが押されたら一時停止・再開を切り替える
        if (Input.GetButtonDown("Cancel") && onOff == false)
        {
            Debug.Log("NN");
            pausePanel?.SetActive(true);
            PauseResume();
            onOff = true;
        }
        else if(Input.GetButtonDown("Cancel") && onOff == true)
        {
            pausePanel?.SetActive(false);
            PauseResume();
            onOff = false;
        }
    }

    /// <summary>
    /// 一時停止・再開を切り替える
    /// </summary>
    void PauseResume()
    {
        m_pauseFlg = !m_pauseFlg;

        // 全ての GameObject を取ってきて、IPause を継承したコンポーネントが追加されていたら Pause または Resume を呼ぶ
        var objects = FindObjectsOfType<GameObject>();

        foreach (var o in objects)
        {
            IPause i = o.GetComponent<IPause>();

            if (m_pauseFlg)
            {
                i?.Pause();     // ここで「多態性」が使われている
            }
            else
            {
                i?.Resume();    // ここで「多態性」が使われている
            }
        }
    }
}
