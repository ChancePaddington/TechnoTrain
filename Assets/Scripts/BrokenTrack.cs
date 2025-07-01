using UnityEngine;

public class BrokenTrack : MonoBehaviour
{
    [SerializeField] private LineColourEnum.LineColour obstacleColour;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<FollowLine>().lineColour == obstacleColour)
            {
                collision.gameObject.SetActive(false);
            }
        }
    }
}
