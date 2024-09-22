using System.Collections.Generic;

using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(EdgeCollider2D))]
[RequireComponent(typeof(SpriteShapeController))]
public class EdgeColliderUpdater : MonoBehaviour
{
    private static EdgeColliderUpdater instance;

    public static EdgeColliderUpdater Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EdgeColliderUpdater>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<EdgeColliderUpdater>();
                    singletonObject.name = typeof(EdgeColliderUpdater).ToString() + " (Singleton)";
                }
            }
            return instance;
        }
    }

    private SpriteShapeController shapeController;
    private EdgeCollider2D edgeCollider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

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
