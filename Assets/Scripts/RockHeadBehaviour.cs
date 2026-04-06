using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RockHeadBehaviour : MonoBehaviour
{
    private float velocityY = 0.5f;
 

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    // Creem un moviment bàsic 
    // Es mou en vertical, amunt i avall entre 2 punts
    void Update() {
        transform.Translate(0, velocityY * Time.deltaTime,  0);

        //El component transform és tan bàsic
        //que el podem fer servir diretament sense crear una variable.
        if (transform.position.y > 0.5) {
            velocityY = -velocityY;
        }
        else if (transform.position.y < -1.3) {
            velocityY = -velocityY;
        }
    }
}

