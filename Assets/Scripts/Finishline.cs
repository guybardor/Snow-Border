using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishline : MonoBehaviour
{

    [SerializeField] private float  Dealy_finishLine = 3f;
    [SerializeField] private ParticleSystem finishLineEffect;
    [SerializeField] private float speed;
     [SerializeField] bool IsFinshiLine;
      
      private void Awake() {
        if (finishLineEffect == null) {
           finishLineEffect = GetComponentInChildren<ParticleSystem>();  
        }
        GameObject levelSprite = GameObject.Find("Level Sprite Shape");
        if (levelSprite != null) {
          speed = levelSprite.GetComponent<SurfaceEffector2D>().speed;
          speed = 0;
          
        }
        setFinishLineStatus(false);
      
      }

      private void OnTriggerEnter2D(Collider2D other) {
      if (other.gameObject.CompareTag("Player")) {
        // Reload the current scene
        setFinishLineStatus(true);
        GetComponent<AudioSource>().Play(); 
        finishLineEffect.Play();  
        Invoke("LoadScene", Dealy_finishLine); 
      }
    }

    private void LoadScene() {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool getFinishLineStatus() {
      return IsFinshiLine;
    }

    private void setFinishLineStatus(bool status) {
      IsFinshiLine = status;
      Debug.Log("Finish Line Status: " + IsFinshiLine);
    }
}
