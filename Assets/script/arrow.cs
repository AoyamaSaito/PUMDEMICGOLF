using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{   

    bool _isUp;
    bool _isDown;

    arrow _move;
    [SerializeField] GameObject[] _gameobject;

    float _counter = 0;
    [SerializeField] float _upCountRimit = 5f;
    [SerializeField] float _dwonCountRimit = 3f;

    camera _cameraMove;
    // Start is called before the first frame update
    void Start()
    {
        _isUp = true;
        _isDown = false;

        GameObject _gameObject = GameObject.Find("arrow");
        GameObject _gameObject2 = GameObject.Find("MainCamera");
        _cameraMove = _gameObject2.GetComponent<camera>();
        _move = _gameObject.GetComponent<arrow>();
        _cameraMove.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (_isUp)
        {
            Debug.Log("今は上に上がる処理");
            if (_counter <= _upCountRimit)
            {
                transform.Rotate(0f, 0f, 180.0f * Time.deltaTime);
                _counter += Time.deltaTime;
            }
            else
            {
                _counter = 0;
                _isUp = false;
                _isDown = true;

            }
        }
        if (_isDown)
        {
            Debug.Log("今は下に下がる処理");
            if (_counter <= _dwonCountRimit)
            {
                transform.Rotate(0f, 0f, -180.0f * Time.deltaTime);
                _counter += Time.deltaTime;
            }
            else
            {
                _counter = 0;
                _isUp = true;
                _isDown = false;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("stop");
            _move.enabled = false;
        }
    }

}


