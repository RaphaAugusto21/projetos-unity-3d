using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private float timedestroy = 10f;
    // Update is called once per frame
    void Update()
    {
        if(timedestroy > 0){
            timedestroy -= Time.deltaTime;
        }else{
            Destroy(gameObject);
        }
    }
}
