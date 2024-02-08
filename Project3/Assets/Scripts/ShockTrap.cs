using UnityEngine;

public class ShockTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GelatinousCube"))
        {
            other.gameObject.GetComponent<GelatinousCubeAI>().Shrink();

            // Destroy this ShockTrap after triggering
            Destroy(gameObject);
        }
    }
}