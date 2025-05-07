using UnityEngine;

public class KeepCabinUpright : MonoBehaviour
{
    void LateUpdate()
    {
        // Mant�m a cabine "em p�" com rota��o apenas vertical
        Vector3 up = Vector3.up;
        Vector3 forward = Vector3.forward;
        transform.rotation = Quaternion.LookRotation(forward, up);
    }
}
