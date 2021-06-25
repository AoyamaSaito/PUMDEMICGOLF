using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class camera : MonoBehaviour
{
    public GameObject zombihead;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = zombihead.transform.position;
        //カメラとプレイヤーの位置を同じにする
        transform.position = new Vector3(playerPos.x, playerPos.y, -10);
    }
}


