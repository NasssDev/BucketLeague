using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public Scoreboard scoreboard;
    public Transform centerSpawnPoint;
    public AudioSource whistleSound;

    // Vitesse à laquelle la balle sera poussée
    public float pushForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            // Ajouter des points au scoreboard
            scoreboard.AddPointForTeam(other.GetComponent<Goal>().team);

            // Jouer le son de sifflet
            whistleSound.Play();

            Debug.Log("But marqué ! La balle va respawn dans 3 secondes.");
            // Respawn de la balle après 3 secondes
            StartCoroutine(RespawnBall());
        }
        else if (other.CompareTag("Player"))
        {
            // Récupérer la direction du contact
            Vector3 pushDirection = (transform.position - other.transform.position).normalized;

            // Appliquer une force à la balle dans la direction opposée au contact
          GameObject ball = GameObject.FindGameObjectWithTag("Ball");
          Rigidbody rb = ball.GetComponent<Rigidbody>();
          rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }

    private IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(3f);
        transform.parent.position = centerSpawnPoint.position;

        Debug.Log("La balle a respawn");
        // Réinitialiser la vitesse ou d'autres propriétés de la balle au besoin
    }
}
