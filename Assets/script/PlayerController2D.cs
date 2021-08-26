using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] float m_movePower = 3f;
    [SerializeField] float m_rotateSpeed = 1.5f;
    Rigidbody2D m_rb = default;
    Vector3 m_inputDirection = default;
    LaserRayCast LRC;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        m_inputDirection = new Vector3(h, v, 0).normalized;
        this.transform.up = Vector3.RotateTowards(this.transform.up, m_inputDirection, Time.deltaTime * m_rotateSpeed, 0);
    }

    private void FixedUpdate()
    {
        m_rb.velocity = m_inputDirection * m_movePower;
    }

    public void ChangeSprite(GameObject shitai)
    {
        Instantiate(shitai, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
