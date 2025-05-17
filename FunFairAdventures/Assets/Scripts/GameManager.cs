using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool wireTaskCompleted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
