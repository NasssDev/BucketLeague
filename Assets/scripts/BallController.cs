using UnityEngine;
using System.Collections;
public class BallController : MonoBehaviour
{
    public Scoreboard scoreboard;
    public Transform centerSpawnPoint;
    public AudioSource whistleSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            // Ajouter des points au scoreboard
            scoreboard.AddPointForTeam(other.GetComponent<Goal>().team);

            // Jouer le son de sifflet
            whistleSound.Play();

            // Respawn de la balle après 3 secondes
            StartCoroutine(RespawnBall());
        }
    }

    private IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(3f);
        transform.position = centerSpawnPoint.position;
        // Réinitialiser la vitesse ou d'autres propriétés de la balle au besoin
    }
}
