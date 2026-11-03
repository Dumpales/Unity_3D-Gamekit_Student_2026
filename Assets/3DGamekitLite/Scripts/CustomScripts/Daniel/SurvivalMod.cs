using System.Timers;
using UnityEngine;

public class SurvivalMod : MonoBehaviour
{
    [SerializeField] private float thirstLevel = 100f;
    [SerializeField] private float thirstSpeed;

    [SerializeField] private bool thirsty;
    [SerializeField] private bool parched;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Subtracting the thirstLevel by thirstSped (normalized using Time.deltaTime, in order to make it framerate independent, and restrict to the max value (=thirstLevel), and min (=0))
        thirstLevel -= Mathf.Clamp(thirstSpeed * Time.deltaTime,0f,thirstLevel);

        if (thirstLevel <= 75f && !thirsty)
        {
            thirsty = true;
            print("I'm thirsty!"); 
        }
        if (thirstLevel <= 50f && !parched)
        {
            parched = true;
            print("I'm parched!"); 
        }
        
        
    }
    
}
