using System;
using System.Timers;
using Gamekit3D;
using UnityEngine;

public class SurvivalMod : MonoBehaviour
{
    [SerializeField] private float thirstLevel = 100f;
    [SerializeField] private float thirstSpeed;

    [SerializeField] private bool thirsty;
    [SerializeField] private bool parched;
    [SerializeField] private bool dying;
    [SerializeField] private float damageTimer = 10;
    [SerializeField] private float damageAmount = 10;
    
    [SerializeField] private GameObject playerObject;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Subtracting the thirstLevel by thirstSped (normalized using Time.deltaTime, in order to make it framerate independent, and restrict to the max value (=thirstLevel), and min (=0))
        thirstLevel -= Mathf.Clamp(thirstSpeed * Time.deltaTime,0f,thirstLevel);
        damageAmount -= Mathf.Clamp(thirstSpeed * Time.deltaTime,1f,thirstLevel);
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
        if (thirstLevel <= 25f  && !dying)
        {
            dying = true;
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0)
            {
                Damageable.DamageMessage msg = new Damageable.DamageMessage()
                {
                    amount = 1,//damageAmount
                    damager = this,
                    damageSource = new Vector3(0, 0, 0),
                    direction = new Vector3(0, 0, 0),
                    throwing = false,
                    stopCamera = false
                };
                playerObject.GetComponent<Damageable>().ApplyDamage(msg);
                print("I'm dying!");
                damageTimer = 10f;
            }
        }
        
    }
    
}
