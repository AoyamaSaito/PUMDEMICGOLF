using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEnterUE : MonoBehaviour
{

    [SerializeField] UnityEvent onTrigger;
    [SerializeField] UnityEvent onCollision;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        onTrigger.Invoke();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        onCollision.Invoke();
    }
}
