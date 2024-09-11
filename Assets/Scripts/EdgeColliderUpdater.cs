using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(EdgeCollider2D))]
[RequireComponent(typeof(SpriteShapeController))]
public class EdgeColliderUpdater : MonoBehaviour
{
    private SpriteShapeController shapeController;
    private EdgeCollider2D edgeCollider;

    void Start()
    {
        shapeController = GetComponent<SpriteShapeController>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        UpdateCollider();
    }

    void UpdateCollider()
    {
        Vector2[] points = new Vector2[shapeController.spline.GetPointCount()];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = shapeController.spline.GetPosition(i);
        }
        edgeCollider.points = points;
    }
}
