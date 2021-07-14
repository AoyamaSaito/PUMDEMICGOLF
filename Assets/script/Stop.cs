using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    gauge _gauge;
    [SerializeField] GameObject[] _gameobject2;
    arrow _move;
    [SerializeField] GameObject[] _gameobject;
    // Start is called before the first frame update
    void Start()
    {
        GameObject _gameObject2 = GameObject.Find("Slider");
        _gauge = _gameObject2.GetComponent<gauge>();
        GameObject _gameObject = GameObject.Find("arrow");
        _move = _gameObject.GetComponent<arrow>();
        Debug.Log("delete");
        _gauge.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("stop");
            Destroy(_move);
            _gauge.enabled = true;
            this.enabled = false;
        }            
    }
}
