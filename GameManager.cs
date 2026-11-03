using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager m_instance;

    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindAnyObjectByType<GameManager>();
            }

            return m_instance;
        }
    }

    public void GameOver()
    {
        Application.Quit();
    }
}