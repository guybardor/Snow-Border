using UnityEngine;

public class PlayerScoreController : MonoBehaviour
{   
    public static PlayerScoreController Instance { get; private set; }
    [SerializeField] private PlayerScoreModel playerScoreModel;
    [SerializeField] private PlayerScoreView playerScoreView;

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }

        if (playerScoreModel == null)
        {
            playerScoreModel = GetComponent<PlayerScoreModel>();

            if (playerScoreModel == null)
            {
                Debug.LogError("PlayerScoreModel is not assigned!");
            }
          
        }
        if (playerScoreView == null)
        {
            playerScoreView = GameObject.Find("PlayerScoreText").GetComponent<PlayerScoreView>();

            if (playerScoreView == null)
            {
                Debug.LogError("PlayerScoreView is not assigned!");
            }
        }
        
    }

    
    private void Start() {
      ResetScore();             // Update the score in the view
    }

    // Method to increase the player's score
    public void AddScore(int points)
    {
        
        playerScoreModel.AddScore(points);  // Update the model
        UpdateScoreUI();                    // Reflect changes in the view
    }
    public void ResetScore()
    {
        Debug.Log("PlayerScoreController.ResetScore() called");
        playerScoreModel.ResetScore();  // Update the model
        playerScoreView.UpdateScoreDisplay(playerScoreModel.Score);                  // Reflect changes in the view
    }   

    // Update the score in the view based on the model
    private void UpdateScoreUI()
    {
        if (playerScoreView != null)
        {
            playerScoreView.UpdateScoreDisplay(playerScoreModel.Score);
        }
    }
}
