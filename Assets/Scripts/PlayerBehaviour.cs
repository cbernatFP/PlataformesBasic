using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float speed = 3f;
    private float jumpForce = 2f;
    private bool isGrounded = true;

    private int contVides = 3;
    private int contFruites = 0;
    public TextMeshProUGUI txtVides;
    public TextMeshProUGUI txtFruites;
    private bool esInmune = false;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();


        txtVides.text = "Vides: 3";
        txtFruites.text = "Fruites: 0";
    }

    void Update() {
        // Moviment horitzontal
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        // Salt
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    // Detectar totes les col·lisions
    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("1111");

        if ((collision.gameObject.tag == "Ground") || (collision.gameObject.tag == "Plataforma")) {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Fruita") {
            Destroy(collision.gameObject);
            contFruites++;

            if (collision.gameObject.name=="Apple")
                StartCoroutine(ActivarInmunidad());
        }

        if (collision.gameObject.tag == "Bomba") {
            if (!esInmune) { 
                contVides--;
                if (contVides < 1)
                    Destroy(this.gameObject);
            }
        }

        if (collision.gameObject.tag == "foc") { 
            if (!esInmune) {
                Destroy(this.gameObject);
            }
        }

        if ((collision.gameObject.name == "Nivell2") && (contFruites >=2)) {
            SceneManager.LoadScene(2);
        }

        txtVides.text = "Vides: " + contVides;
        txtFruites.text = "Fruites: " + contFruites;
    }


    private IEnumerator ActivarInmunidad() {
        esInmune = true;  // Activar inmunidad
        sr.color = Color.red;
        transform.localScale += new Vector3(0.5f, 0.5f, 0f);
        jumpForce = 5f;
        yield return new WaitForSeconds(10);  // Esperar 2 segundos
        esInmune = false; // Desactivar inmunidad
        sr.color = Color.white;
        jumpForce = 2f;
        transform.localScale -= new Vector3(0.5f, 0.5f, 0f);

    }

}
