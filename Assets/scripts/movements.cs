using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement du personnage
    public float jumpForce = 10f; // Force du saut
    private bool isGrounded; // Variable pour vérifier si le personnage touche le sol
    public float tpX = 2f;
    public float tpY = 1f;
    public float tpZ = -2f;


    void Update()
    {
        // Déplacement horizontal et vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcul du mouvement en fonction des inputs
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        // Appliquer le mouvement horizontal au personnage
        transform.Translate(movement, Space.World);

        // Saut
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }



    }


}
