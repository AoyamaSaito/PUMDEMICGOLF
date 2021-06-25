using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoter : MonoBehaviour
{
    [SerializeField] GameObject[] _gameobject;
    [SerializeField] GameObject[] _gameobject2;
    [SerializeField] Transform m_muzzle = default;
    [SerializeField] float m_Speed = 5f;
    Rigidbody2D m_rb = default;
    gauge _slider;
    float m_timer = 0;
    float m_interval = 1.5f;
    camera _cameraMove;

    // Start is called before the first frame update
    void Start()
    {
        GameObject _gameObject = GameObject.Find("zombihead");
        GameObject _gameObject2 = GameObject.Find("MainCamera");
        _slider = GameObject.Find("Slider").GetComponent<gauge>();
        _cameraMove = _gameObject2.GetComponent <camera>();
        m_rb = GetComponent<Rigidbody2D>();
        _cameraMove.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("shot");
            m_rb.velocity = m_muzzle.transform.right * m_Speed*_slider.value;
            this.transform.rotation = m_muzzle.rotation;
            Destroy(this.GetComponent<shoter>());
            _cameraMove.enabled = true;
        }
    }
}
