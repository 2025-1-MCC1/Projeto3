using UnityEngine;

public class KeepCabinUpright : MonoBehaviour
{
    void LateUpdate()
    {
        // Mantém a cabine "em pé" com rotação apenas vertical
        Vector3 up = Vector3.up;
        Vector3 forward = Vector3.forward;
        transform.rotation = Quaternion.LookRotation(forward, up);
    }
}
