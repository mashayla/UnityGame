/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   private int DetectCollisions(Vector3 pos) 
{        
    Collider[] hitColliders = Physics.OverlapSphere(pos, radius);
    return hitColliders.Length;
}

IEnumerator SpawnObjects()
{
    selectedObject = letters[Random.Range(0, letters.Length)];

    while (amount < limit)
    {
        Vector3 spawnPos = new Vector3(Random.Range(35.0f, 950.0f), 13.0f, Random.Range(35.0f, 950.0f));
        // Check collisions
        if (DetectCollisions(spawnPos) > 0)
            continue;

        Instantiate(selectedObject, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(5.0f);
        amount++;
    }
}

}
*/