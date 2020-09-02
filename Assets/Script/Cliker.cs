using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliker : MonoBehaviour
{
    public static bool lockMouse;
    public bool click = false;
    public cubitos myType;
    public Generador myGenerador;

  /*  public void Awake()
    {
      lockMouse = true;

    }*/
void Start()
    {
        myGenerador = FindObjectOfType<Generador>();
    }
    void Update()
    {
        if(click == true)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.up * 180, 2 * Time.deltaTime));
        }
        else
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.zero, 2 * Time.deltaTime));
        }

    }
    private void OnMouseDown()
    {
        if (Generador.inGame)
        {
            if (!lockMouse)
            {
                myGenerador.AddCube(this.gameObject);
                click = true;
            }
        }
    }
  
}

