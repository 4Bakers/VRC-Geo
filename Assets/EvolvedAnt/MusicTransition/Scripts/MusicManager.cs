
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

// Created by: EvolvedAnt#0001 (Discord)
// Created on: 1/14/2023
// Version: 1.1

// INSTRUCTIONS: Add ALL audio sources you intend to utilize for transitions in the MusicCollection
//               field in the inspector.
//               See the MusicTrigger script for information on how to activate a transition

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class MusicManager : UdonSharpBehaviour
{
    private float timerElapsed = 0f;
    private AudioSource TransitionTo;
    private float targetVolume = 1f;
    private float transitionToVolume = 0f;
    private float[] transitionFromVolumes;

    [Tooltip("List ALL audio sources you intend to utilize for music transitions.")]
    [SerializeField] private AudioSource[] MusicCollection;

    [Tooltip("How long it will take to smoothly transition from one audio source, to the next.")]
    [SerializeField] private float transitionTime = 3f;

    [Space]
    [Tooltip("Enable direct control of exactly the shape of the transition from one audio source to another.")]
    [SerializeField] private bool UseCurves = false;
    [SerializeField] private AnimationCurve TransitionCurve;

    

    void Start()
    {
        timerElapsed = transitionTime;
        transitionFromVolumes = new float[MusicCollection.Length];
    }

    public void AttemptTransition(AudioSource TransitionTo, float targetVolume, bool reset)
    {
        this.TransitionTo = TransitionTo;
        this.targetVolume = targetVolume;
        timerElapsed = 0f;
        
        if (reset && this.TransitionTo.volume == 0f)
            this.TransitionTo.Play();

        // Cache the initial volumes of all audio sources in the Music Collection
        transitionToVolume = this.TransitionTo.volume;
        for (int i = 0; i < transitionFromVolumes.Length; i++)
            transitionFromVolumes[i] = MusicCollection[i].volume;

        if (transitionTime <= 0)
            transitionTime = 0.01f;
    }

    void Update()
    {
        if (timerElapsed < transitionTime)
        {
            timerElapsed += Time.deltaTime;

            // Raise the audio source volume requested by the trigger
            if (TransitionTo.volume < 1f)
                if (UseCurves)
                    TransitionTo.volume = Mathf.Lerp(transitionToVolume, targetVolume, TransitionCurve.Evaluate(timerElapsed / transitionTime));
                else
                    TransitionTo.volume = Mathf.Lerp(transitionToVolume, targetVolume, timerElapsed / transitionTime);

            // Lower all other audio sources from the Music Collection
            for (int i = 0; i < MusicCollection.Length; i++)
            {
                if (MusicCollection[i] != TransitionTo) // Skip the audio source whose volume we are raising
                    if (MusicCollection[i].volume > 0f)
                        if (UseCurves)
                            MusicCollection[i].volume = Mathf.Lerp(transitionFromVolumes[i], 0f, TransitionCurve.Evaluate(timerElapsed / transitionTime));
                        else
                            MusicCollection[i].volume = Mathf.Lerp(transitionFromVolumes[i], 0f, timerElapsed / transitionTime);
            }

        }
    }
}
