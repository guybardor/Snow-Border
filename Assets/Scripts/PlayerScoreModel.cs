using UnityEngine;

public class PlayerScoreModel : MonoBehaviour
{
    [SerializeField] private int score;
    

    // Property to get the current score
    
    public int Score
    {
        get { return score; }
    }

    // Method to add score
    public void AddScore(int value)
    {
        score += value;
    }

    // Method to reset score
    public  void ResetScore()
    {
        
        score = 0;
    }
}
