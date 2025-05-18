using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;
    public float mouseSensitivity = 100f; // Sensibilidade aumentada

    private CharacterController controller;
    private float verticalVelocity;
    private Transform cameraTransform;
    private float cameraPitch = 0f;
    private bool inputEnabled = false;
    private CursorController cursorController;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Obter ou adicionar o controlador de cursor
        cursorController = GetComponent<CursorController>();
        if (cursorController == null)
        {
            cursorController = gameObject.AddComponent<CursorController>();
        }

        // Encontrar a câmera
        cameraTransform = transform.Find("Main Camera");
        if (cameraTransform == null)
        {
            Debug.LogError("Camera not found as a child of the player object!");
            return;
        }

        // Resetar rotação da câmera
        cameraPitch = 0f;
        cameraTransform.localRotation = Quaternion.identity;

        // Bloquear cursor usando o controlador dedicado
        cursorController.LockCursor();

        // Atrasar o processamento de entrada para evitar salto inicial do mouse
        StartCoroutine(EnableInputAfterDelay(0.5f));
    }

    IEnumerator EnableInputAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Descartar valores iniciais do mouse para evitar saltos
        float discardX = Input.GetAxis("Mouse X");
        float discardY = Input.GetAxis("Mouse Y");

        // Habilitar entrada
        inputEnabled = true;
        Debug.Log("Input enabled, camera control should now work");
    }

    void Update()
    {
        // Só processar entrada se habilitada
        if (!inputEnabled)
            return;

        ProcessMovement();
        ProcessRotation();
    }

    void ProcessMovement()
    {
        // Verificação de solo
        bool isGrounded = controller.isGrounded;
        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        // Obter eixos de entrada
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular direção do movimento relativa à orientação do personagem
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Converter direção local para espaço global baseado na orientação do jogador
        Vector3 moveVector = transform.TransformDirection(moveDirection) * moveSpeed;

        // Lidar com pulo
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Aplicar gravidade
        verticalVelocity += gravity * Time.deltaTime;

        // Definir componente vertical do movimento
        moveVector.y = verticalVelocity;

        // Aplicar movimento
        controller.Move(moveVector * Time.deltaTime);
    }

    void ProcessRotation()
    {
        // Usar GetAxisRaw para movimentos mais responsivos
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotacionar o jogador horizontalmente
        transform.Rotate(Vector3.up * mouseX);

        // Rotacionar a câmera verticalmente
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -85f, 85f);

        // Aplicar rotação à câmera
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
    }
}