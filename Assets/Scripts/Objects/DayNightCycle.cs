using Garden;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

    Animator animator;

    [SerializeField] Calendar calendar;
    
    // [SerializeField] SpriteRenderer dawn;
    // [SerializeField] SpriteRenderer midday;
    // [SerializeField] SpriteRenderer sunset;
    // [SerializeField] SpriteRenderer midnight;

    // [SerializeField] SpriteRenderer fadeInRenderer;
    // [SerializeField] SpriteRenderer fadeOutRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Cach the animator component
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Change the background
    /// </summary>
    /// <param name="value"></param>
    public void Animate(string value)
    {        
        switch (value)
        {
            case "dawn":{                
                   
                calendar.ChangeDay();
                animator.SetTrigger("dawn");
                break;

            }
                
            case "midday":{
               animator.SetTrigger("mid");
                break;
            }
                
            case "sunset":{
               animator.SetTrigger("sunset");
                break;
            }
                
            case "midnight":{
                animator.SetTrigger("night");
                break;
            }
        
        } 
    

       
    }
}
