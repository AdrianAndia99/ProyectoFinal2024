using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfObjects { get; private set; }

    public UnityEvent<PlayerInventory> OnDiamondCollected;

    public void DiamondCollected()
    {
        NumberOfObjects++;
        OnDiamondCollected.Invoke(this);

    }
}