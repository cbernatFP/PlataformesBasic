using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour_Nivell2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float speed = 3f;
    private float jumpForce = 4f;
    private bool isGrounded = true;

    private int contVides = 3;
    private int contPunts = 0;
    public TextMeshProUGUI txtVides;   //Els components de text on pintarem vides i punts
    public TextMeshProUGUI txtPunts;

    public Transform spawnPoint;



    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();


        txtVides.text = "Vides: 3";
        //txtPunts.text = "Punts: 0";
    }

    void Update() {

        // Moviment horitzontal
        float moveX = Input.GetAxis("Horizontal");
        Debug.Log(moveX);
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        // Salt
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    // Tractar totes les col·lisions detectades
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Tilemap") 
            isGrounded = true;
        
        if (collision.gameObject.tag == "GameOver") {
            contVides--;
        
            if (contVides == 0) 
                SceneManager.LoadScene("GameOver");
            else
                transform.position = spawnPoint.position;
        }

        txtVides.text = "Vides: " + contVides;
        //txtPunts.text = "Punts: " + contPunts;
    }


}
