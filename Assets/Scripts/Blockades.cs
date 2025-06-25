using UnityEngine;

public class Blockades : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collidercollidin");
            collision.gameObject.SetActive(false);
        }
    }
}
