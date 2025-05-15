using System;
using UnityEngine;

public class mao : MonoBehaviour
{
    GameObject objeto;
    bool pegou;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
        
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("teste") && pegou == false  )
        {
            Debug.Log("Peguei o item");
            other.gameObject.transform.position = this.transform.position;
            pegou = true;
        }
    }
}
