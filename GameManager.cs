using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 필요합니다.

public class GameManager : MonoBehaviour
{
    // 1. 싱글톤 인스턴스를 담을 내부 변수
    private static GameManager m_instance;

    // 변수들
    public bool inDrawing = false;
    Vector3 prevPosition = new Vector3(0, 0, 0);

    public GameObject spherePrefab;
    public TextMeshProUGUI messageText;
    public Camera arCamera;

    // 2. 외부에서 접근할 수 있는 싱글톤 프로퍼티
    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindAnyObjectByType<GameManager>();
                
                if (m_instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    m_instance = obj.AddComponent<GameManager>();
                }
            }
            return m_instance;
        }
    }

    private void Awake()
    {
        // 중복 생성 방지 및 파괴 방지 설정
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (m_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        Application.Quit();
    }

    public void ShowMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
        }
        else
        {
            Debug.LogWarning("messageText is not connected!");
        }
    }

    private void Update()
    {
        DrawSpheres();
    }

    void DrawSpheres()
    {
        // inDrawing 변수명 오류 수정 완료
        if (inDrawing == false) return;
        if (arCamera == null || spherePrefab == null) return;

        // vector3 -> Vector3 대소문자 오류 수정 완료
        Vector3 currentPosition = arCamera.ScreenToWorldPoint(
            new Vector3(Screen.width / 2, Screen.height / 2, 0.5f));

        float distance = Vector3.Distance(currentPosition, prevPosition);
        if (distance < 0.3f) return;

        GameObject go = Instantiate(spherePrefab, currentPosition, Quaternion.identity);
        go.transform.parent = transform;
        prevPosition = go.transform.position;
    }
}