using UnityEngine;
using UnityEngine.InputSystem;

public class CannonNewInput : MonoBehaviour
{
    public GameObject shellPrefab;
    public Transform fireTrans;

    GameObject shell;

    void OnFire(InputValue value) // 1. vlaue -> value 오타 수정
    {
        // 2. shellprefeb -> shellPrefab 스펠링 및 대소문자 수정
        shell = Instantiate(shellPrefab, fireTrans.position, fireTrans.rotation);
        
        // 3. shellController -> ShellController (클래스명)
        // 4. shoot -> Shoot (함수명)
        // 5. transfor.up -> transform.up (또는 포신 앞방향인 fireTrans.forward 추천)
        shell.GetComponent<ShellController>().Shoot(fireTrans.forward);
    }
}