using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float attackRange = 5f; // The range within which the weapon can hit enemies
    public LayerMask enemyLayer; // Layer mask to specify which layers are considered enemies

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button is used for attacking
        {
            Attack();
        }
    }

    void Attack()
    {
        // Perform a raycast from the weapon's position in the direction it's facing
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange, enemyLayer))
        {
            // Check if the hit object has an Enemy component
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Make the enemy immovable for 3 seconds
                StartCoroutine(enemy.MakeImmovable(3f));
            }
        }
    }
}