using System.Collections;
using UnityEngine;

public class CarouselController : MonoBehaviour
{
    public float rotationSpeed = 20f;
    public float pauseDuration = 5f;
    public float runDuration = 15f;

    public Transform[] horses;
    public float horseMoveAmplitude = 0.5f;  // Altura do sobe e desce
    public float horseMoveSpeed = 2f;        // Velocidade do movimento vertical

    private Vector3[] initialHorsePositions;
    private bool isPaused = false;

    void Start()
    {
        // Armazena as posições iniciais dos cavalos
        initialHorsePositions = new Vector3[horses.Length];
        for (int i = 0; i < horses.Length; i++)
        {
            initialHorsePositions[i] = horses[i].localPosition;
        }

        // Inicia a rotação controlada
        StartCoroutine(RotationCycle());
    }

    void Update()
    {
        // Gira o carrossel se não estiver pausado
        if (!isPaused)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Movimento vertical dos cavalos
        AnimateHorses();
    }

    void AnimateHorses()
    {
        for (int i = 0; i < horses.Length; i++)
        {
            Vector3 pos = initialHorsePositions[i];
            pos.y += Mathf.Sin(Time.time * horseMoveSpeed + i) * horseMoveAmplitude;
            horses[i].localPosition = pos;
        }
    }

    IEnumerator RotationCycle()
    {
        while (true)
        {
            isPaused = false;
            yield return new WaitForSeconds(runDuration);

            isPaused = true;
            yield return new WaitForSeconds(pauseDuration);
        }
    }
}
