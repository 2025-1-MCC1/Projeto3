using UnityEngine;

public class SeatBeltController : MonoBehaviour
{
    public Transform belt;             // Parte do cinto que gira
    public float openAngle = -90f;
    public float speed = 90f;

    private float targetAngle = 0f;
    private float currentAngle = 0f;
    private bool isMoving = false;

    void Update()
    {
        if (!isMoving) return;

        float step = speed * Time.deltaTime;
        currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, step);
        belt.localRotation = Quaternion.Euler(0f, 0f, currentAngle);

        if (Mathf.Approximately(currentAngle, targetAngle))
            isMoving = false;
    }

    public void OpenBelt()
    {
        targetAngle = openAngle;
        isMoving = true;
    }

    public void CloseBelt()
    {
        targetAngle = 0f;
        isMoving = true;
    }
}
