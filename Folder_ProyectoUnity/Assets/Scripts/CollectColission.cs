using UnityEngine;

public class CollectCollision : MonoBehaviour
{
    public AudioSource audo;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.DiamondCollected();
            gameObject.SetActive(false);
            audo.Play();
        }
    }
}