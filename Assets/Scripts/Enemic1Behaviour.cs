using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemic1Behaviour : MonoBehaviour
{
    public float velocityX = 1f;
    SpriteRenderer MySprite;        //Declarem una variable de tipus
                                    //SpriteRenderer que es diu mySprite


    // Start is called before the first frame update
    void Start() {
        MySprite = GetComponent<SpriteRenderer>();
        //Agafem l'SpriteRenderer associat a aquest script,
        //que és el del MasDude
    }

    void Update() {
        transform.Translate(velocityX * Time.deltaTime, 0, 0);
    }

    // Creem un moviment bàsic
    // Es mou en horitzontal i quan toca el Tilemap gira cap a l'altra banda
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Tilemap") {
            MySprite.flipX = !MySprite.flipX;
            velocityX = -velocityX;
        }
    }
}
