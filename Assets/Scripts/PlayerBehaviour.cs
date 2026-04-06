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
    private bool tocaTerra = true;  // Per controlar si el personatge toca terra. Si no toca terra no pot saltar

    private int contVides = 3;
    private int contPunts = 0;
    public TextMeshProUGUI txtVides;   // Els components de text on pintarem vides i punts
    public TextMeshProUGUI txtPunts;
    public TextMeshProUGUI txtMissatge;
    private bool esInmune = false;     // Quan el personatge recull una poma activarem la inmunitat


    void Start() {
        rb = GetComponent<Rigidbody2D>();    // Agafem el component RigidBody. Per moure el Player
        sr = GetComponent<SpriteRenderer>(); // Agafem el component RigidBody. Per canviar l'aparença


        txtVides.text = "Vides: 3";
        txtPunts.text = "Punts: 0";
        txtMissatge.text = "";

    }

    void Update() {
        // Moviment horitzontal
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        // Salt. Només es pot saltar mentre estem tocant a terra
        // Quan comencem a saltar "guardem" que ja no toca terra
        if (Input.GetKeyDown(KeyCode.Space) && tocaTerra) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            tocaTerra = false;
        }
    }

    // Detectar totes les col·lisions
    void OnCollisionEnter2D(Collision2D collision) {

        // Si toquem "terra"
        if ((collision.gameObject.tag == "Ground") || (collision.gameObject.tag == "Plataforma")) {
            tocaTerra = true;
        }

        // Hem col.lisionat amb una fruita
        if (collision.gameObject.tag == "Fruita") {
            Destroy(collision.gameObject);
            txtMissatge.text = "";

            // La fruita és una poma
            if (collision.gameObject.name == "Apple") {
                StartCoroutine(ActivarInmunidad());
                contPunts += 5;
            }
            else   // La fruita és una síndria
                contPunts++;
        }

        // Si ens cau una bomba només només perdem una vida quan no som inmunes
        // Si perdem totes les vides, Game Over
        if (collision.gameObject.tag == "Bomba") {      // If anidat
            if (!esInmune) {
                contVides--;
                if (contVides == 0)
                    SceneManager.LoadScene("GameOver");
            }
        }

        // Si caiem al foc i no som inmunes, Game Over
        if ((collision.gameObject.tag == "foc") && (!esInmune))  //If amb dues condicions
            SceneManager.LoadScene("GameOver");
        

        // Si arribem a la marca per canviar de nivell....
        if (collision.gameObject.name == "Nivell2") {
            if (contPunts > 3)
                SceneManager.LoadScene(2);
            else
                txtMissatge.text = "Per passar al nivell 2 has de tenir 3 punts";
        }

        // Un cop gestionades les col.lisions actualitzem els "comptadors"
        txtVides.text = "Vides: " + contVides;
        txtPunts.text = "Fruites: " + contPunts;
    }


    private IEnumerator ActivarInmunidad() {
        // Activem la inmunitat
        esInmune = true;                                        // Activar inmunidad
        sr.color = Color.red;                                   // Posar-lo de color vermell
        transform.localScale += new Vector3(0.5f, 0.5f, 0f);    // Fer-lo més gran
        jumpForce = 5f;                                         // Salta molt

        // Esperaem
        yield return new WaitForSeconds(10);  

        // Desactivem al inmunitat
        esInmune = false; 
        sr.color = Color.white;
        jumpForce = 2f;
        transform.localScale -= new Vector3(0.5f, 0.5f, 0f);
    }

}
