using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingObject : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField]Transform _TrackingTarget = null;
    Transform _MyPosition;
    float _Transform;
    // Start is called before the first frame update
    void Start()
    {
        _MyPosition.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
        _TrackingTarget = Target.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //_Transform = _TrackingTarget.position.x;
        //transform.Translate(_Transform,0,0);
        this.transform.position = new Vector3(this.transform.position.x, -5,0);
        //Debug.Log("MOVE");
        //Debug.Log(_TrackingTarget.position.x);
    }
}
