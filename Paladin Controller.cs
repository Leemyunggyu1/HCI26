using UnityEngine;
using UnityEngine.InputSystem;

public class PaladinController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotateSpeed = 2f;

    private float move;
    private float rotate;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody가 없습니다. Paladin에 Rigidbody를 추가하세요.");
        }
    }

    private void Update()
    {
        if (Mathf.Abs(move) > 0.1f || Mathf.Abs(rotate) > 0.1f)
        {
            Rotate();
        }
    }

    private void FixedUpdate()
    {
        if (rb == null)
            return;

        if (Mathf.Abs(move) > 0.1f)
        {
            Move();
        }
    }

    public void OnMove(InputValue value)
    {
        move = value.Get<float>();
    }

    public void OnRotate(InputValue value)
    {
        rotate = value.Get<float>();
    }

    private void Move()
    {
        Vector3 moveDir = transform.forward * move * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDir);
    }

    private void Rotate()
    {
        float rotSpeed = rotate * rotateSpeed * Time.deltaTime;

        rb.MoveRotation(
            rb.rotation * Quaternion.Euler(0f, rotSpeed, 0f)
        );
    }
}