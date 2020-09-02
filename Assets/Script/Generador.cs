using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generador : MonoBehaviour
{
    public AudioClip soundWin, soundPoint, soundLose;
    public Text puntos; 
    public int myPuntos = 0;
    public Text contador;
    public static float contraReloj = 60f; //tiempo del turno
    public float velocidad = 1f; // velocidad del tiempo
    public bool myClick; 
    public static bool inGame = true;
    public Material[] materiales= new Material[8];
    public GameObject pieza;
    public List<Material> myList = new List<Material>(16);
    Dictionary<Material, cubitos> dict = new Dictionary<Material, cubitos>();
    public Material temporal;
    public GameObject first, second, timeUp, winner;
    bool tiempofuera = true;
    bool playSound = false;
    private void Awake()
    {
        inGame = true;
    }
    void Start()
    {
        for (int i = 0; i < materiales.Length; i++)
        {
            myList.Add(materiales[i]);
            myList.Add(materiales[i]);
        }
        for (int i = 0; i < materiales.Length; i++)
        {
            dict.Add(materiales[i], (cubitos)i);
        }

        Shuffle(ref myList);
        
        for (int i = 0; i < 16; i++)
        {
            pieza.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material = myList[i];
            pieza.transform.GetChild(i).GetChild(0).GetComponent<Cliker>().myType = dict[myList[i]];
        }
    }
    private void Update()
    {
        puntos.text = "Puntos:" + myPuntos;
        contador.text = "Tiempo:" + contraReloj.ToString("f0");
        if (tiempofuera == true)
        {
            contraReloj -= Time.deltaTime;

        }
        if (contraReloj <= 0.0f && myPuntos != 8)
        {
            inGame = false; 
            tiempofuera = false;
            timeUp.SetActive(true);
            if (playSound == false && myPuntos != 8)
            {
                AudioSource.PlayClipAtPoint(soundLose, Camera.main.transform.position);
                playSound = true;
            }


        }
        if (myPuntos == 8)
        {
            winner.SetActive(true);
            AudioSource.PlayClipAtPoint(soundWin, Camera.main.transform.position);
            myPuntos = 0;
        }
      
    }
    public static void Shuffle (ref List<Material> list)
    {

        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n+1);
            Material value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

    }
    public void AddCube(GameObject cube)
    {
        if (first == null)
        {
            first = cube;
        }
        else if (first != cube)
        {
            second = cube;
            Comprobacion();
            Cliker.lockMouse = true;

        }

    }
    public void Comprobacion()
    {
        if (first.GetComponent<Cliker>().myType == second.GetComponent<Cliker>().myType)
        {
           Invoke("Coincide",1f);
        }
        else if (first.GetComponent<Cliker>().myType != second.GetComponent<Cliker>().myType)
        {
          Invoke("NoCoincide",1f);
        
        }
    }
    void Coincide ()
    {
        Destroy(first);
        Destroy(second);
        Cliker.lockMouse = false;
        if (myPuntos != 7)
        {
            AudioSource.PlayClipAtPoint(soundPoint, Camera.main.transform.position);
        }
        myPuntos = myPuntos + 1;
    }
    void NoCoincide()
    {
        first.GetComponent<Cliker>().click = false;
        second.GetComponent<Cliker>().click = false;
        first = null;
        second = null;
        Cliker.lockMouse = false;

    }
 

}
public enum cubitos { cubo0, cubo1, cubo2, cubo3, cubo4, cubo5, cubo6, cubo7 }
