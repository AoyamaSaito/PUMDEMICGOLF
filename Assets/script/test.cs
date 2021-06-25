using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    bool _isUp;
    bool _isDown;

    float _counter = 0;
    [SerializeField]float _upCountRimit = 5f;
    [SerializeField]float _dwonCountRimit = 3f;
    // Start is called before the first frame update
    void Start()
    {
        _isUp = true;
        _isDown = false;

        StartCoroutine(SwapFunction());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_isUp)
        {
            Debug.Log("今は上に上がる処理");
            if (_counter <= _upCountRimit)
            {
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
                _counter += Time.deltaTime;
            }
            else
            {
                _counter = 0;
                _isUp = true;
                _isDown = false;
            }
        }
        
    }

    IEnumerator SwapFunction()
    {
        while (true)
        {
            while (_counter < _upCountRimit)
            {
                Debug.Log("上に上がる処理");
                _counter += Time.deltaTime;
                yield return null;
            }
            _counter = 0;
            while (_counter < _dwonCountRimit)
            {
                Debug.Log("下に下がる処理");
                _counter += Time.deltaTime;
                yield return null;
            }
            _counter = 0;
            yield return null;
        }
    }
}
