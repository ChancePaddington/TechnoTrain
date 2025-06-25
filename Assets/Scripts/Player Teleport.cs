using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public Junction junction;

    private void Start()
    {
        junction = gameObject.GetComponent<Junction>();
    }

    //private void Update()
    //{
    //    if (junction.currentTeleporter != null)
    //    {
    //        transform.position = junction.currentTeleporter.GetComponent<Junction>().Teleport();
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //Checks if collision with tagged object
    //    if (collision.CompareTag("Teleporter"))
    //    {
    //        currentTeleporter = collision.gameObject;

    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject == currentTeleporter)
    //    {
    //        currentTeleporter = null;
    //    }
    //}
}
