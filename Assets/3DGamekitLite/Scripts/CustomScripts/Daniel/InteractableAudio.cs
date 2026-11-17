using FMODUnity;
using UnityEngine;

public class InteractableAudio : MonoBehaviour
{
    [SerializeField] private EventReference pickupHealthAudio, SFX_RockDestroy, switchAudio, doorAudio;
    // Plays a oneshot sound when healing
    void PickupHealthPlay()
    {
        RuntimeManager.PlayOneShot(pickupHealthAudio);
    }

    // Plays a spatialized sound when destroying a box
    public void SFX_RockDestroyPlay(Transform objectTransform)
    {
       RuntimeManager.PlayOneShot(SFX_RockDestroy, objectTransform.position); 
    }
}
