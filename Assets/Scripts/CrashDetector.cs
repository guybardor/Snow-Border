using System.Collections;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    private static CrashDetector instance;
    [SerializeField] private bool IsCrash = false;
    [SerializeField] private bool canCollideWithGround = true; // Prevent multiple collisions with the ground

    public static CrashDetector Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CrashDetector>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<CrashDetector>();
                    singletonObject.name = typeof(CrashDetector).ToString() + " (Singleton)";
                    
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
          
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy duplicates of the singleton
            return;
        }
        IsCrash = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canCollideWithGround && other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Crash!");
            LifeManager.Instance.ReduceLife(); // Example of calling another singleton
            StartCoroutine(DelayCollision()); // Start the coroutine for handling delay
        }
    }

    private IEnumerator DelayCollision()
    {
        canCollideWithGround = false;

        // Call the ResetPosition method from the PlayerController class
        PlayerController.Instance.ResetPosition();

        yield return new WaitForSeconds(5f);

        canCollideWithGround = true;
    }
}
