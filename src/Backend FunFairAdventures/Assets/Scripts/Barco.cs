using UnityEngine;

public class VikingBoat : MonoBehaviour
{
    public float speed = 1.5f;           // Velocidade da oscilação
    public float maxAngle = 45f;         // Ângulo máximo de inclinação

    private float angle = 0f;            // Ângulo atual do barco

    void Update()
    {
        // Calcula o ângulo baseado no tempo
        angle = maxAngle * Mathf.Sin(Time.time * speed);

        // Aplica a rotação no eixo Z (como um pêndulo)
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
