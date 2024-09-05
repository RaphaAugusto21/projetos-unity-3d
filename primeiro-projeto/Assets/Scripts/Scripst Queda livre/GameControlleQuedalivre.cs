using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlleQuedalivre : MonoBehaviour
{
    public GameObject objetoQuedaLivre;
    public Rigidbody objetoBola;

    public Vector3 posicaoBola;
    public float velocidadeBola;
    public float aceleracaoBola;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0f;

        if(objetoQuedaLivre)
            objetoBola = objetoQuedaLivre.GetComponent<Rigidbody>();      
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(objetoBola)
        {
            posicaoBola = objetoBola.position;
            velocidadeBola = objetoBola.velocity.magnitude;
            aceleracaoBola = Physics.gravity.y;
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
}
