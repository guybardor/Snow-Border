using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
	public static LifeManager Instance { get; private set; }
    [SerializeField] private float Dealy_finishLine = 3f;

	[SerializeField] private int startingLives = 3;
    

	[SerializeField]private int currentLives;

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
		
	}

	private void Start()
	{
		currentLives = startingLives;
		// Update the UI
		UIManager.Instance.UpdateLifeUI(currentLives);
	}

	public void ReduceLife()
	{
		currentLives--;
        // Update the UI
        UIManager.Instance.UpdateLifeUI(currentLives);
		if (currentLives <= 0)
		{
			// Game over
			Debug.Log("Game over!");
			// Reload the current scene using the build index
        	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	

	public int GetCurrentLives()
	{
		return currentLives;
	}
}