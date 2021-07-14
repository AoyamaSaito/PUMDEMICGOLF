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
    [SerializeField] GameObject destroy;
    [SerializeField] GameObject destroy2;
    Rigidbody2D m_rb = default;
    Slider _slider;
    CameraControl _cameraMove;
    public float torque;
    [SerializeField] float turn = 0;
    [SerializeField] Vector3 m_center;

    // Start is called before the first frame update
    void Start()
    {
        GameObject _gameObject = GameObject.Find("zombihead");
        GameObject _gameObject2 = GameObject.Find("MainCamera");
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        _cameraMove = _gameObject2.GetComponent <CameraControl>();
        m_rb = GetComponent<Rigidbody2D>();
        m_rb.centerOfMass = m_center;
        _cameraMove.enabled = false;
        SwitchToNear();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("shot");
            if (m_farVCam)
            {
                //m_farVCam.MoveToTopOfPrioritySubqueue();
                m_farVCam.Priority = 11;
            }
            m_rb.velocity = m_muzzle.transform.right.normalized * _slider.value;
            this.transform.rotation = m_muzzle.rotation;
            this.enabled = false;
            Destroy(destroy);
            Destroy(destroy2);
            _cameraMove.enabled = true;
            m_rb.AddTorque(turn * torque);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Invoke("SwitchToNear", 0.01f);
        }
    }

    private void SwitchToNear()
    {
        if (m_nearVCam)
        {
            //m_nearVCam.MoveToTopOfPrioritySubqueue();
            m_nearVCam.Priority = 12;
        }
    }
}
