using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class GameControlleQuedalivre : MonoBehaviour
{
    public GameObject objetoQuedaLivre;
    public Rigidbody objetoBola;

    public Vector3 posicaoBola;
    public float velocidadeBola;
    public float aceleracaoBola;
    public GameObject textoG;
    public GameObject textoV;
    public GameObject textoK;
    public GameObject textoU;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0f;

        if(objetoQuedaLivre){
            objetoBola = objetoQuedaLivre.GetComponent<Rigidbody>();
            textoG = GameObject.Find("Gnumber");
            textoV = GameObject.Find("Vnumber");
            textoK = GameObject.Find("ECnumber");
            textoU = GameObject.Find("EPnumber");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(objetoBola)
        {
            posicaoBola = objetoBola.position;
            velocidadeBola = objetoBola.velocity.magnitude;
            aceleracaoBola = Physics.gravity.y;

            textoG.GetComponent<TextMeshProUGUI>().text = (-1*aceleracaoBola) + " m/s²";
            textoV.GetComponent<TextMeshProUGUI>().text = Mathf.RoundToInt(velocidadeBola) + " m/s";
            textoK.GetComponent<TextMeshProUGUI>().text = EnergiaCinetica() + " J";
            textoU.GetComponent<TextMeshProUGUI>().text = EnergiaPotencial() + " J";
        }
    }   

    public void StartGame(){
        Time.timeScale = 1f;
    }

    public void StopGame(){
        Time.timeScale = 0f;
    }

    public void ResetGame(){
        UnityEngine.SceneManagement.Scene courrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(courrentScene.name);
    }

    private int EnergiaPotencial(){
        return (Mathf.RoundToInt((-1)*objetoBola.mass*aceleracaoBola*objetoBola.position.y));
    }

    private int EnergiaCinetica(){
        return (Mathf.RoundToInt((objetoBola.mass*velocidadeBola*velocidadeBola)/2));
    }
}
