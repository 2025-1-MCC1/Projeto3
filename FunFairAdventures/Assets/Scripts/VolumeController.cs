using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [Header("Referências")]
    public Slider volumeSlider;         // O Slider na UI
    public AudioSource musicSource;     // O AudioSource que toca a música

    void Start()
    {
        // Define o valor inicial do slider com base no volume atual
        volumeSlider.value = musicSource.volume;

        // Adiciona o listener para detectar mudanças no slider
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float value)
    {
        // Atualiza o volume da música conforme o slider
        musicSource.volume = value;
    }
}
