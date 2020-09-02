using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEsena : MonoBehaviour
{
    public AudioClip soundButon;
    public void NivelUno()
    {
        SceneManager.LoadScene("ModoFacil");
        Generador.contraReloj = 60f;
        AudioSource.PlayClipAtPoint(soundButon, Camera.main.transform.position);
        if (Cliker.lockMouse)
        {
            Cliker.lockMouse = !Cliker.lockMouse;
        }
    }
    public void NivelDos()
    {
        SceneManager.LoadScene("ModoDificil");
        AudioSource.PlayClipAtPoint(soundButon, Camera.main.transform.position);
        Generador.contraReloj = 30f;
        if (Cliker.lockMouse)
        {
            Cliker.lockMouse = !Cliker.lockMouse;
        }
    }
    public void Menu()
    {
        AudioSource.PlayClipAtPoint(soundButon, Camera.main.transform.position);
        SceneManager.LoadScene("Menu");
    }

}
