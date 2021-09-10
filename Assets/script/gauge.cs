using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gauge : MonoBehaviour
{
    shoter _shoter;
    public Slider _slider;
    [SerializeField] float _max;
    [SerializeField] float _min;

    bool _up;
    bool _down;

    bool _isAdding;

    camera _cameraMove;
    // Start is called before the first frame update
    void Start()
    {
        GameObject _gameObject = GameObject.Find("zombihead");
        _shoter = _gameObject.GetComponent<shoter>();
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        GameObject _gameObject2 = GameObject.Find("MainCamera");
        _cameraMove = _gameObject2.GetComponent<camera>();
        _slider.value = 0;
        _up = true;
        _down = false;
        _shoter.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_up)
        {
            if (_slider.value < 120f)
            {

                _slider.value += 2.5f;
                Debug.Log("add");
            }
            else
            {
                Debug.Log("else");
                _up = false;
                _down = true;
            }
        }
        if (_down)
        {
            if (_slider.value > 40)
            {
                Debug.Log("minus");
                _slider.value -= 2.5f;
            }
            else
            {
                _up = true;
                _down = false;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("stop");
            Destroy(this);
            _shoter.enabled = true;
        }
        //if (_isAdding) _slider.value += 0.1f;
        //else _slider.value -= 0.1f;

        //if (_slider.value >= _slider.maxValue) _isAdding = false;
        //else if (_slider.value <= _slider.minValue) _isAdding = true;






    }
}
