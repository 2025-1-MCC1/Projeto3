using UnityEngine;

public class PlayerItemInteraction : MonoBehaviour
{
    public Transform handPoint; // Referência ao ponto na mão
    private GameObject itemNearby; // Item próximo
    private GameObject itemHeld;   // Item segurado

    public float raycastDistance = 3f; // Distância do Raycast (pode ajustar conforme necessário)

    void Update()
    {
        // Pegar item por proximidade (detecção por Trigger)
        if (itemNearby != null && Input.GetKeyDown(KeyCode.E) && itemHeld == null)
        {
            PickUpItem();
        }

        // Pegar item por Raycast (mirando diretamente no item)
        if (Input.GetKeyDown(KeyCode.E) && itemHeld == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance)) // Raycast para pegar item
            {
                if (hit.collider.CompareTag("Item"))
                {
                    itemNearby = hit.collider.gameObject;
                    PickUpItem();
                }
            }
        }

        // Soltar item
        if (itemHeld != null && Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
        }
    }

    void PickUpItem()
    {
        itemHeld = itemNearby;
        itemHeld.transform.SetParent(handPoint);
        itemHeld.transform.localPosition = Vector3.zero; // Ajuste conforme necessário
        itemHeld.transform.localRotation = Quaternion.identity;
        itemHeld.GetComponent<Rigidbody>().isKinematic = true; // Impede física enquanto estiver na mão
    }

    void DropItem()
    {
        itemHeld.transform.SetParent(null);
        Rigidbody rb = itemHeld.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.linearVelocity = Vector3.zero; // Remove qualquer movimento anterior
        itemHeld = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemNearby = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemNearby = null;
        }
    }
}
