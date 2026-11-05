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
    [SerializeField] private int damageAmount = 1;
    
    [SerializeField] private GameObject playerObject;
    public bool isDead = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerObject = GameObject.FindWithTag("Player");
       isDead = false;
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
        if (thirstLevel <= 25f  && parched)
        {
            dying = true;
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0)
            {
                if (dying)
                    print("I'm dying of thirst!");
                Damageable.DamageMessage msg = new Damageable.DamageMessage()
                {
                    amount = damageAmount,
                    damager = this,
                    damageSource = new Vector3(0, 0, 0),
                    direction = new Vector3(0, 0, 0),
                    throwing = false,
                    stopCamera = false
                };
                playerObject.GetComponent<Damageable>().ApplyDamage(msg);
                damageTimer = 10.0f;
                //playerObject.GetComponent<Damageable>().OnDeath(resetThirst);
                //playerObject.GetComponent<Damageable>().currentHitPoints(resetThirst = true);
            }
        }
    }
//ResetThirst gets called when OnDeath, resets all thirst params
    public void ResetThirst()
    {
        thirstLevel = 100f;
        thirsty = false;
        parched = false;
        dying = false;
    }

}
