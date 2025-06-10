using UnityEngine;

public class LineManager : MonoBehaviour
{
    private LineRenderer lineRender;
    public Transform[] points;

    private void Awake()
    {
        lineRender = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] points)
    {
        lineRender.positionCount = points.Length;
        this.points = points;
    }

    private void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            lineRender.SetPosition(i, points[i].position);
        }
    }

}
