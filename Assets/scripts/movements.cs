using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;

    void Update()
    {
        // Déplacement horizontal et vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcul du mouvement en fonction des inputs
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * Speed * Time.deltaTime;

        // Appliquer le mouvement horizontal au personnage
        transform.Translate(movement, Space.Self); // Utilisation de Space.Self

        if (Input.GetKey(KeyCode.Q))
        {
            GetComponent<Transform>().Rotate(new Vector3(0, -RotationSpeed * Time.deltaTime, 0), Space.Self);
        }
        if (Input.GetKey(KeyCode.E))
        {
            GetComponent<Transform>().Rotate(new Vector3(0, RotationSpeed * Time.deltaTime, 0), Space.Self);
        }
    }
}
