using UnityEngine;

public class ShellController : MonoBehaviour
{
    public float speed = 100f;
    int lifetime = 5;

    private void Start()
    {
        Shoot(transform.forward);
        Destroy(gameObject, lifetime);
    }

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir * speed);
    }
}