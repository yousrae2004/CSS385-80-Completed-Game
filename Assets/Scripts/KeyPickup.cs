using UnityEngine;

public class KeyPickup : MonoBehaviour
{
       public AudioSource pickupSound; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding is the Player
        if (other.CompareTag("Player"))
        {
            GameGlobals.hasKey = true;
            Debug.Log("Item picked up!");

            if (pickupSound != null)
            {
                
                pickupSound.Play();
    
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
                
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}