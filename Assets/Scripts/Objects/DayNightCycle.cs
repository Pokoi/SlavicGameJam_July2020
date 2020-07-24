using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

    Animator animator;
    
    [SerializeField] Sprite dawn;
    [SerializeField] Sprite midday;
    [SerializeField] Sprite sunset;
    [SerializeField] Sprite midnight;

    [SerializeField] SpriteRenderer fadeInRenderer;
    [SerializeField] SpriteRenderer fadeOutRenderer;

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
            case "dawn":
                fadeInRenderer.sprite = dawn;
                fadeOutRenderer.sprite = midnight;
                break;

            case "midday":
                fadeInRenderer.sprite = midday;
                fadeOutRenderer.sprite = dawn;
                break;

            case "sunset":
                fadeInRenderer.sprite = sunset;
                fadeOutRenderer.sprite = midday;
                break;

            case "midnight":
                fadeInRenderer.sprite = midnight;
                fadeOutRenderer.sprite = sunset;
                break;
        } 
        
        animator.SetTrigger("Change");
    }
}
