using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 moveDir = transform.forward * Time.deltaTime * speed;
        rb.MovePosition(moveDir + rb.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
