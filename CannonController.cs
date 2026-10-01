using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject shellPrefab;
    public Transform fireTrans;

    GameObject shell;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // 포탄 생성
            shell = Instantiate(
                shellPrefab,
                fireTrans.position,
                fireTrans.rotation
            );

            // 포탄 발사
            shell.GetComponent<ShellController>().Shoot(fireTrans.forward);
        }
    }
}