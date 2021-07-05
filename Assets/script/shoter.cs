using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoter : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCameraBase m_nearVCam = default;
    [SerializeField] CinemachineVirtualCameraBase m_farVCam = default;
    [SerializeField] GameObject[] _gameobject;
    [SerializeField] GameObject[] _gameobject2;
    [SerializeField] Transform m_muzzle = default;
    [SerializeField] float m_Speed = 5f;
    [SerializeField] GameObject destroy;
    [SerializeField] GameObject destroy2;
    Rigidbody2D m_rb = default;
    Slider _slider;
    float m_timer = 0;
    float m_interval = 1.5f;
    CameraControl _cameraMove;

    // Start is called before the first frame update
    void Start()
    {
        GameObject _gameObject = GameObject.Find("zombihead");
        GameObject _gameObject2 = GameObject.Find("MainCamera");
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        _cameraMove = _gameObject2.GetComponent <CameraControl>();
        m_rb = GetComponent<Rigidbody2D>();
        _cameraMove.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("shot");
            if (m_farVCam)
            {
                m_farVCam.MoveToTopOfPrioritySubqueue();
                Invoke("SwitchToNear", 2f);
            }
            m_rb.velocity = m_muzzle.transform.right.normalized * _slider.value;
            this.transform.rotation = m_muzzle.rotation;
            this.enabled = false;
            Destroy(destroy);
            Destroy(destroy2);
            _cameraMove.enabled = true;
        }
    }

    private void SwitchToNear()
    {
        if (m_nearVCam)
        {
            m_nearVCam.MoveToTopOfPrioritySubqueue();
        }
    }
}
