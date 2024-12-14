
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

// Created by: EvolvedAnt#0001 (Discord)
// Created on: 1/14/2023
// Version: 1.1

// INSTRUCTIONS: 1. Add this script to a box collider with the Is Trigger flag set
//               2. Assign the audio source you want to play when activated
//               3. Make sure there is a MusicManager in the scene, and that it has
//                  ALL audio sources you intend to use for smooth transitions
//                  assigned to the Music Collection field
// !! IMPORTANT !!
// Make sure the audio sources for transitions have Loop and 2D audio enabled

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class MusicTrigger : UdonSharpBehaviour
{
    [Tooltip("Assign the gameobject here that has the MusicActivator script. Make sure you assign ALL the music you intend to utilize for music transitions to the MusicManager.")]
    [SerializeField] private MusicManager musicManager;
    
    [Tooltip("Assign the audio source you intend to transition to when the player touches this trigger. (It MUST be listed in the MusicManager as well)")]
    [SerializeField] private AudioSource TransitionTo;
    
    [SerializeField] [Range(0.01f, 1.0f)] 
    [Tooltip("The volume you want this audio source to reach when the transition completes.")]
    private float Volume = 1f;

    [SerializeField][Tooltip("This only occurs if the audio source has reached 0 volume, otherwise the audio will continue from where it left off.")]
    private bool PlayAudioFromBegining = false;

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player.isLocal)
            musicManager.AttemptTransition(TransitionTo, Volume, PlayAudioFromBegining);
    }
}
