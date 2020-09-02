using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float seed = 1; 
   
  

    void Update()
    {
        transform.position += transform.up * seed * Time.deltaTime;

        Invoke("detruir",20);
    }
  
      void detruir()
    {
        Destroy(gameObject);
    }
       void OnTriggerEnter(Collider other) 
    {

         if (other.GetComponent<carrito>())
        {
           
            Destroy(gameObject);
        } 
    }
}
