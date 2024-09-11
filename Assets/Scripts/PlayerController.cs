using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float m_Torque = 1f;
   [SerializeField] private Rigidbody2D m_rigidbody = null;
   [SerializeField] private float BostSpeed = 30; 
   [SerializeField] private float NormalSpeed = 60f;
   CrashDetector crashDetector = null; 
   Finishline finishline = null;
   SurfaceEffector2D m_surfaceEffector2D;

   
    private void Awake() 
    {
        m_surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
        crashDetector = new CrashDetector();
        finishline = new Finishline();

    }
    private void   Start() 
    {
        
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_surfaceEffector2D.speed = NormalSpeed;    
          
    }

    private void FixedUpdate()
    {
       
        if(crashDetector.getCrashStatus() == false && finishline.getFinishLineStatus() == false)    
        {
            move();
            ResponsePeriot();
        }
        else{
            Debug.Log("Game Over"); 
        }
       
       
    }

    private void ResponsePeriot()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            m_surfaceEffector2D.speed +=BostSpeed;
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
            m_surfaceEffector2D.speed -=BostSpeed;
        }
      
    }

    private void move()
    {
       if(Input.GetKey(KeyCode.LeftArrow))
       {
           m_rigidbody.AddTorque(m_Torque);

       }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            m_rigidbody.AddTorque(-m_Torque);
        }
    }
}
