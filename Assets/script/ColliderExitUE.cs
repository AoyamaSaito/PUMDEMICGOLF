using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderExitUE : MonoBehaviour
{

    [SerializeField] UnityEvent onTrigger;
    [SerializeField] UnityEvent onCollision;

    public void OnTriggerExit2D(Collider2D collision)
    {
        onTrigger.Invoke();
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        onCollision.Invoke();
    }
}
