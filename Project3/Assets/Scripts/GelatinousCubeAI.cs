using UnityEngine;

public class GelatinousCubeAI : MonoBehaviour
{
    public Transform playerTransform;
    public PlayerController playerController; // Reference to the player's controller script
    public GreenFilmEffect greenFilmEffect;
    public float moveSpeed = 5.0f;
    public float detectionRange = 20.0f;
    public float absorbRange = 3.0f;
    public GameObject keyPrefab;
    private int shrinkCount = 0;
    private const int maxShrink = 4; // The cube disappears after 4 shrinks
    
    private bool isPlayerAbsorbed = false;

    void Start() {
        // Ensure that the green film is not initially visible
        greenFilmEffect.DisableGreenFilm();
    }

    void Update()
    {
        if (isPlayerAbsorbed) return; // Stop updating if the player is already absorbed

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // Move towards the player if not within absorb range
        if (distanceToPlayer < detectionRange && distanceToPlayer > absorbRange)
        {
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
        }
        else if (distanceToPlayer <= absorbRange)
        {
            AbsorbPlayer();
        }
    }

    void AbsorbPlayer()
    {
        // Move the player to the cube's position (inside the cube)
        playerTransform.position = transform.position;

        // Disable the player's movement
        if (playerController != null)
        {
            playerController.enabled = false;
        }

        // Attempt to get the Rigidbody component from the cube and the player
        Rigidbody cubeRigidbody = GetComponent<Rigidbody>();
        Rigidbody playerRigidbody = playerTransform.GetComponent<Rigidbody>();

        if (cubeRigidbody != null)
        {
            // Disable cube's physics interactions by setting isKinematic to true
            cubeRigidbody.isKinematic = true;
        }

        if (playerRigidbody != null)
        {
            // Disable player's physics interactions by setting isKinematic to true
            playerRigidbody.isKinematic = true;
        }

        // Call EnableGreenFilm to apply the green film "absorbed" effect
        if (greenFilmEffect != null)
        {
            greenFilmEffect.EnableGreenFilm();
        }

        isPlayerAbsorbed = true;
    }

    public void Shrink()
    {
        transform.localScale *= 0.5f; // Halve the size of the cube
        absorbRange *= 0.5f;
        shrinkCount++;

        if (shrinkCount >= maxShrink)
        {
            DropKey();
            Destroy(gameObject); // Destroy the cube
        }
    }

    void DropKey()
    {
        // Instantiate the key at the cube's position
        GameObject droppedKey = Instantiate(keyPrefab, transform.position, Quaternion.identity);
        
        // Add a Rigidbody component to the dropped key
        Rigidbody keyRigidbody = droppedKey.AddComponent<Rigidbody>();
        
        // Configure the Rigidbody
        keyRigidbody.useGravity = true;
        keyRigidbody.isKinematic = false;
    }

}
