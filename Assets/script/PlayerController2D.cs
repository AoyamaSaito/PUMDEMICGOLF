using UnityEngine;

public class PlayerController2D : MonoBehaviour , IPause
{
    [SerializeField] float m_movePower = 3f;
    [SerializeField] float m_rotateSpeed = 1.5f;
    Rigidbody2D m_rb = default;
    Vector3 m_inputDirection = default;
    bool move = true;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (move)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            m_inputDirection = new Vector3(h, v, 0).normalized;
        }
    }

    public void FixedUpdate()
    {
        if (move)
        {
            this.transform.up = Vector3.RotateTowards(this.transform.up, m_inputDirection, Time.deltaTime * m_rotateSpeed, 0);
            m_rb.velocity = m_inputDirection * m_movePower;
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
