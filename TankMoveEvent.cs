using UnityEngine;
using UnityEngine.InputSystem;

public class TankMoveEvent : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotateSpeed = 2f;
    float move;
    float rotate;
    Rigidbody rb;

    // 수정: start() -> Start() (대소문자 수정으로 NullReferenceException 해결)
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Mathf.Abs(move) > 0.1f || Mathf.Abs(rotate) > 0.5f)
        {
            Move();
            Rotate();
        }
    }

    // void OnMove(InputValue value)
    // {
    //     move = value.Get<float>();
    // }

    // void OnRotate(InputValue value)
    // {
    //     rotate = value.Get<float>();
    // }

    public void OnTankMove(InputAction.CallbackContext context)
    {
        // Debug.Log("Move");
        //Debug.Log("Move value :" + context.ReadValue<float>());
        move = context.ReadValue<float>();

    }

     public void OnTankRotate(InputAction.CallbackContext context)
    {
        // Debug.Log("Move");
        Debug.Log("Rotate value :" + context.ReadValue<float>());
        rotate = context.ReadValue<float>(); // 수정된 부분

    }

    void Move()
    {
        Vector3 moveDir = transform.forward * move * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDir);
    }
    
    void Rotate()
    {
        float rotSpeed = rotate * rotateSpeed * Time.deltaTime;
        rb.rotation = Quaternion.Euler(0, rotSpeed, 0) * rb.rotation;
    }
}