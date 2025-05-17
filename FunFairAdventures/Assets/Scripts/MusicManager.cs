using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip menuMusic;
    public AudioClip gameMusic;

    private AudioSource audioSource;
    private string currentScene;

    void Awake()
    {
        // Padr�o Singleton para manter apenas uma inst�ncia entre cenas
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Configura��o inicial
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.volume = 0.5f;

            // Registra o evento para detectar mudan�as de cena
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Toca a m�sica da cena atual
            PlayMusicForCurrentScene();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForCurrentScene();
    }

    void PlayMusicForCurrentScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        // Evita tocar a mesma m�sica novamente
        if (currentScene == sceneName)
            return;

        currentScene = sceneName;

        // Seleciona a m�sica com base na cena atual
        if (sceneName == "Menu")
        {
            if (menuMusic != null)
                PlayMusic(menuMusic);
        }
        else if (sceneName == "Jogo")
        {
            if (gameMusic != null)
                PlayMusic(gameMusic);
        }
    }

    void PlayMusic(AudioClip music)
    {
        if (audioSource.clip == music && audioSource.isPlaying)
            return;

        audioSource.clip = music;
        audioSource.Play();
    }

    // M�todos p�blicos para controlar a m�sica
    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp01(volume);
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }

    public void ResumeMusic()
    {
        audioSource.UnPause();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
