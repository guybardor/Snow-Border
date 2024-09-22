using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI lifeText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(gameObject);
        }
        try
        {
            lifeText = GameObject.Find("LifePanelText").GetComponent<TextMeshProUGUI>();
        }
        catch
        {
            Debug.LogWarning("LifePanelText not found");
        }   
    
        
    }

    public void UpdateLifeUI(int currentLives)
    {
        if (lifeText != null)
        {
            lifeText.text = "Lives: " + currentLives;
        }
    }
}