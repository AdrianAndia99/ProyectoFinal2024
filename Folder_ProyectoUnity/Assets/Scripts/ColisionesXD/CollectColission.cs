using UnityEngine;

public class CollectCollision : MonoBehaviour
{
    public GameObject doorObject;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.DiamondCollected();

            doorObject.SetActive(false);
            gameObject.SetActive(false);

        }
    }
}