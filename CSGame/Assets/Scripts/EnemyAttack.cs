using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damagePercentage = 0.5f; // 50% damage
    private PlayerController playerController; // Reference to the PlayerController script

    private void Start()
    {
        // Assuming the player GameObject has a PlayerController component
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.ReduceHPByPercentage(damagePercentage);
        }
    }
}