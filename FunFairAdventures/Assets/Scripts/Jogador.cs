using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class Scripts : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;
    public float mouseSensitivity = 2f;

    private CharacterController controller;
    private Vector2 velocity;
    private bool isGrounded;

    private Transform cam;

    public int moedasColetadas;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = transform.Find("Main Camera");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Checagem de solo
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Mantém o personagem preso no chão
        }

        // Entada de movimento
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * moveSpeed * Time.deltaTime);

        //Pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravidade 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Rotação com o mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        cam.Rotate(Vector3.right * -mouseY);
    }
    // moedas
    public void GanharMoeda()
    {
        moedasColetadas += 1;
    }

    //para interagir 

interface IInteractable
{
    public void Interact();
}
public class Interação : MonoBehaviour
{
    public Transform InteractionSource; // Fonte de interação

    public float InteractionRange; // Alcance da interação

    public InputActionReference interactionInputAction;

    private void OnEnable()
    {
        //interactionInputAction.action.performed += Interact;
    }

    private void OnDisable()
    {
        //interactionInputAction.action.performed -= Interact;
    }
    //private void Interact(InputAction.CallbackContext obj)
    //{
    //    //Vector3 interactionPosition = InteractionSource.position + Vector3.up;
    //    InteractionSource.position += new Vector3(0, 1f, 0);
    //    Ray playerAim = new Ray(InteractionSource.position, InteractionSource.forward);
    //
    //    // Desenha o raio na aba Scene para visualização
    //    Debug.DrawRay(playerAim.origin, playerAim.direction * InteractionRange, Color.red, 1f);
    //
    //    Debug.Log("lançando raio");
    //
    //    if (Physics.Raycast(playerAim, out RaycastHit hitInfo, InteractionRange))
    //    {
    //        
    //        if (hitInfo.collider.TryGetComponent(out IInteractable interactableObj))
    //        {
    //            interactableObj.Interact();
    //        }
    //    }
    //}

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 interactionPosition = InteractionSource.position + Vector3.up * 2.5f; // mirar o npc com o player (escolher player no inspector e alterar p range do raio)
            //Vector3 interactionPosition = InteractionSource.position; // mirar o npc com a FreeLookCam (escolher player no inspector e alterar p range do raio)
            //InteractionSource.position += new Vector3(0, 1f, 0);
            Ray playerAim = new Ray(interactionPosition, InteractionSource.forward);

            // Desenha o raio na aba Scene para visualização
            Debug.DrawRay(playerAim.origin, playerAim.direction * InteractionRange, Color.red, 1f);

            //Debug.Log("lançando raio");

            if (Physics.Raycast(playerAim, out RaycastHit hitInfo, InteractionRange))
            {

                if (hitInfo.collider.TryGetComponent(out IInteractable interactableObj))
                {
                    interactableObj.Interact();
                }
            }
        }
    }
}
}
