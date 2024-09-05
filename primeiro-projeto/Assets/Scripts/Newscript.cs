using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Newscript : MonoBehaviour
{
    public float forca;
    public float velocidade;
    public float angularVelocity;
    private Rigidbody game;
    public GameObject projetioprefab;
    public Transform posiFire;


    public float test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            ResultanteF();
        }
    }

    private void ResultanteF()
    {
        GameObject projetio = Instantiate(projetioprefab, posiFire.position, transform.rotation);

        Rigidbody rg = projetio.GetComponent<Rigidbody>();
        
        if(rg != null){
            rg.AddForce(posiFire.transform.forward * forca);
        }
    }
}
