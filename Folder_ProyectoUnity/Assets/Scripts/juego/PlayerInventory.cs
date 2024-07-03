using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfObjects { get; private set; }

    public UnityEvent<PlayerInventory> OnItemCollected;

    public void DiamondCollected()
    {
        NumberOfObjects++;
        OnItemCollected.Invoke(this);

    }
}