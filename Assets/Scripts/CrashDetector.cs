using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour

{

    [SerializeField] private float  Dealy_finishLine = 3f;
    [SerializeField] public AudioClip m_AudioClip;
    [SerializeField] private bool Iscrash;
    [SerializeField] private AudioSource m_AudioSource;
   
   private void Awake() {
        setCrashStatus(false);  
        m_AudioSource = GetComponent<AudioSource>();
       m_AudioSource.Play();
       
    }


private void OnTriggerEnter2D(Collider2D other) 
{
    if (other.gameObject.CompareTag("Ground")) 
    {
        //m_AudioSource.PlayOneShot(m_AudioClip); 
        setCrashStatus(true); 
        m_AudioSource.PlayOneShot(m_AudioClip);  
        Invoke("LoadScene", Dealy_finishLine);    
    }

} 

 private void LoadScene() {
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public bool getCrashStatus() {
    return Iscrash;
  }

  private  void setCrashStatus(bool status) {
    Iscrash = status;
  }



}