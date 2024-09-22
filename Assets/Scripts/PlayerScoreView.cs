using System; // Add using directive for System namespace
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // Reference to the UI Text element

    private void Awake() {
       try {
       

          if (scoreText == null)
          {
             
            scoreText = GetComponent<TextMeshProUGUI>();
            if(scoreText == null)
            {
               Debug.LogError("ScoreText is not assigned!");
            }
            else
            {
               Debug.Log("we found the score text " + scoreText.text);
            }

          }
       }
       catch (Exception e) {
          Debug.LogError("An error occurred during Awake: " + e.Message);
       }
    }
    

    // Method to update the score on the UI
    public void UpdateScoreDisplay(int score)
    {
      Debug.Log("Score is " + score.ToString());   // Log the score to the console   
      if (scoreText != null)
      {
         scoreText.text = "Score is " +  score.ToString();
      }
      else
      {
         Debug.LogError("ScoreText is not assigned!");
      }
    }
}
