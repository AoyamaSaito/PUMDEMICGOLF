using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainStop : MonoBehaviour , IPause
{
    // Start is called before the first frame update
    ParticleSystem PS;

    void Start()
    {
        PS = GetComponent<ParticleSystem>();
    }
    void IPause.Pause()
    {
        PS.Stop();
    }

    void IPause.Resume()
    {
        PS.Play();
    }
}
