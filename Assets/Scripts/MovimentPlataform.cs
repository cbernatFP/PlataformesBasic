using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentPlataform : MonoBehaviour
{
    public float speed = 1f;      // Velocitat del moviment
    public float height = 1f;   // Alçada màxima amunt i avall

    private Vector3 startPos;

    void Start() {
        startPos = transform.position;
    }

    void Update() {
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
