using System.Collections;
using UnityEngine;

public class FerrisWheelController : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public Transform[] cabins;               // Cabines fixas, fora da roda
    public Transform bottomPoint;            // Ponto inferior de referência
    public float stopThreshold = 2f;

    private bool isPaused = false;

    void Start()
    {
        StartCoroutine(WheelRoutine());
    }

    IEnumerator WheelRoutine()
    {
        while (true)
        {
            // Gira por 3 segundos
            float elapsed = 0f;
            while (elapsed < 3f)
            {
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Parar a roda
            isPaused = true;

            // Encontrar cabine mais próxima do ponto inferior
            Transform targetCabin = GetClosestCabinToBottom();

            // Abrir porta (0s - 2s)
            CabinDoor door = targetCabin?.GetComponentInChildren<CabinDoor>();
            if (door != null) door.OpenDoor();
            yield return new WaitForSeconds(2f);

            // Espera com porta aberta (2s - 3s)
            yield return new WaitForSeconds(1f);

            // Fechar porta (3s - 5s)
            if (door != null) door.CloseDoor();
            yield return new WaitForSeconds(2f);

            isPaused = false;
        }
    }

    Transform GetClosestCabinToBottom()
    {
        Transform closest = null;
        float minDist = Mathf.Infinity;

        foreach (Transform cabin in cabins)
        {
            float dist = Vector3.Distance(cabin.position, bottomPoint.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = cabin;
            }
        }

        return (minDist <= stopThreshold) ? closest : null;
    }
}
