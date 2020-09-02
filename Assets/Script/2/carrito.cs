using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class carrito : MonoBehaviour
{
    public float velocity = 0.1f;
    public Vector3 dPosition = new Vector3(-1.40f, 0 , -0.40f);
    public Vector3 aPosition = new Vector3(-5.40f, 0 , -0.40f);
    public static bool inGame =  true; 
    public GameObject enemy; 
    public int punto = 0;

    public Text puntos;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine ("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        Movi();

        puntos.text = "" + punto;
    }
     void OnTriggerEnter(Collider other) 
    {

         if (other.GetComponent<Enemy>())
        {
            carrito.inGame = false; 
            Destroy(gameObject);
        } 
    }

    public void Movi ()
    {
         if(Input.GetKey(KeyCode.D))
        {
            transform.position = dPosition;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = aPosition;
        }
 
    }
    public void Ingrementador()
    {
      
    }
    IEnumerator Spawn()
    { 
        while (inGame)
        {
         int rnd = Random.Range(0,2);
         switch (rnd)
         {
             case 0: 
                    enemy = Instantiate(enemy,new Vector3(1.25f,8f,0f), Quaternion.Euler(0,0,180));
             break;
             case 1:
                     enemy = Instantiate(enemy,new Vector3(5f,8f,0f), Quaternion.Euler(0,0,180));
             break;

         } 
          punto++;

           yield return new WaitForSeconds (6); 
        }
        
    }
  
}