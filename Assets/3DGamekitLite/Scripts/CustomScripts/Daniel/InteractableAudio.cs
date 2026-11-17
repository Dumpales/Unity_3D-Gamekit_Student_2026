using FMODUnity;
using FMOD.Studio;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableAudio", menuName = "Scriptable Objects/InteractableAudio")]

public class InteractableAudio : ScriptableObject
{
    [SerializeField] private EventReference pickupHealthAudio, SFX_oneshot_RockDestroy, switchAudio, ENV_oneshot_Door, DoorOpen;
    public bool doorOpened = false;
    
   //declaring an EventInstance to use for playing and stopping doorSounds or similar SFX
    private EventInstance eventInstance;
    
    // Plays a oneshot sound when healing
    void PickupHealthPlay()
    {
        RuntimeManager.PlayOneShot(pickupHealthAudio);
    }

    // Plays a spatialized sound when destroying a box
    public void SFX_RockDestroyPlay(Transform objectTransform)
    {
       RuntimeManager.PlayOneShot(SFX_oneshot_RockDestroy, objectTransform.position); 
    }

    public void Door()
    {
        RuntimeManager.PlayOneShot(ENV_oneshot_Door);
        {
            if (doorOpened);
            
        }
        
    }
}
