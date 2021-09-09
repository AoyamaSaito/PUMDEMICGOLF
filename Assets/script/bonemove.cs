using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonemove : MonoBehaviour , IPause
{
    [SerializeField] float m_movePower = 3f;
    Rigidbody2D m_rb = default;
    Vector3 inputDirection;
    Animator anim;
    bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h < 0)
        {
            h = 0;
        }
        inputDirection = new Vector3(h, 0, 0).normalized;

        if (h > 0)
        {
            anim.Play("zombibone");
        }
        else
        {
            anim.Play("zombibonewait");
        }
    }

    private void FixedUpdate()
    {
        if (move)
        {
            m_rb.velocity = inputDirection * m_movePower;
        }
    }

    void IPause.Pause()
    {
        move = !move;
        m_rb.Sleep();
    }

    void IPause.Resume()
    {
        move = !move;
        m_rb.WakeUp();
    }
}
