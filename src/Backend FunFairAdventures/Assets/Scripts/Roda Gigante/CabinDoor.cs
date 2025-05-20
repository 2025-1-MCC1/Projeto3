using UnityEngine;

public class CabinDoor : MonoBehaviour
{
    public Transform door;
    public float openAngle = -90f;
    public float openSpeed = 90f;

    private float targetAngle = 0f;
    private float currentAngle = 0f;
    private bool isMoving = false;

    void Update()
    {
        if (!isMoving) return;

        float step = openSpeed * Time.deltaTime;
        currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, step);
        door.localRotation = Quaternion.Euler(0f, currentAngle, 0f);

        if (Mathf.Approximately(currentAngle, targetAngle))
            isMoving = false;
    }

    public void OpenDoor()
    {
        targetAngle = openAngle;
        isMoving = true;
    }

    public void CloseDoor()
    {
        targetAngle = 0f;
        isMoving = true;
    }
}
