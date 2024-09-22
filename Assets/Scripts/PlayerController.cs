using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] private float m_Torque = 1f;
    [SerializeField] private Rigidbody2D m_rigidbody = null;
    [SerializeField] private float BoostSpeed = 30f;
    [SerializeField] private float NormalSpeed = 60f;

    private float initialRotation;
    private float currentRotation;
    private bool isInAir = false;
    private float totalRotation = 0f;

    SurfaceEffector2D m_surfaceEffector2D;
  

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
          
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        m_surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_surfaceEffector2D.speed = NormalSpeed;
    }

    private void FixedUpdate()
    {
        Move();

        // Check if player is in the air and track rotation
        if (isInAir)
        {
            TrackRotation();
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_rigidbody.AddTorque(m_Torque);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            m_rigidbody.AddTorque(-m_Torque);
        }
    }

    // Call this when the player jumps or leaves the ground
    public void EnterAir()
    {
        isInAir = true;
        initialRotation = transform.eulerAngles.z; // Track the initial rotation
        totalRotation = 0f; // Reset total rotation count
    }

    // Call this when the player lands
    public void ExitAir()
    {
        isInAir = false;
        AwardPointsBasedOnRotation();
        totalRotation = 0f; // Reset for the next jump
    }

    private void TrackRotation()
    {
        currentRotation = transform.eulerAngles.z;
        float rotationDifference = Mathf.DeltaAngle(initialRotation, currentRotation); // Calculate the difference in rotation

        totalRotation += Mathf.Abs(rotationDifference); // Accumulate the total rotation
        initialRotation = currentRotation; // Update the initial rotation for the next frame
    }

    private void AwardPointsBasedOnRotation()
    {
        // Award points based on total degrees rotated in the air
        int score = 0;
        if (totalRotation >= 45f)
        {
            score = (int)((totalRotation / 45f) * 50); // 50 points for every 45 degrees
        }

        // Add score via the PlayerScoreController
        PlayerScoreController.Instance.AddScore(score);
        Debug.Log("Total Rotation: " + totalRotation + " degrees. Score Awarded: " + score);
    }

    // Reset the player's position to a defined spot
    public void ResetPosition()
    {
        // Disable the Rigidbody2D to prevent physics interactions while resetting
        m_rigidbody.simulated = false;

        // Optionally, reset the rotation as well
        transform.rotation = Quaternion.Euler(-2.505f, -7.012f, -5.425f); // Modify based on how you want the player to face

        // Enable the Rigidbody2D again
        m_rigidbody.simulated = true;

        Debug.Log("Player rotation reset.");
    }
}
