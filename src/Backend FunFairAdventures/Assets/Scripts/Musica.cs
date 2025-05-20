using UnityEngine;

public class Musica : MonoBehaviour
{
    public static Musica instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // mant�m o objeto entre as cenas
        }
        else
        {
            Destroy(gameObject); // evita m�ltiplas m�sicas tocando
        }
    }
}