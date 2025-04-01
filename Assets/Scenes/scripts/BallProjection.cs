using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LineController : MonoBehaviour
{
    public int TrajectoryPoints;
    public LineRenderer _LineRenderer;
    public Vector3[] Points;

    // Start is called before the first frame update

    public void UpdateTrajectory (Vector3 StartPosition, Vector3 StartVelocity)
    {
        Points = new Vector3[TrajectoryPoints];
        Points[0] = StartPosition;
        Vector3 Gravity = Physics.gravity;
        float TimeStep = 0.2f;

        for (int i = 1; i < Points.Length; i++)
        {
            float Time = i * TimeStep;
            Points[i] = StartPosition + StartVelocity * Time + 0.5f * Gravity * Time * Time;
        }
        _LineRenderer.SetPositions(Points);
    }
}
