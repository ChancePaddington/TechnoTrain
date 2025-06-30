using UnityEngine;

public class Blockades : MonoBehaviour
{
    public SpeedManager speedManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collidercollidin");
            speedManager.Deceleration();
        }
    }
}
