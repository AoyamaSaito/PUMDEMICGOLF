using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnabledOff()
    {
        this.gameObject.SetActive(false);
    }

    public void EnabledOn()
    {
        this.gameObject.SetActive(true);
    }

}
