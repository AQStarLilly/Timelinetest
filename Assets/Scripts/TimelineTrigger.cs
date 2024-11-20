using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector playableDirector;
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayTimeline();
            hasPlayed = true;
        }
    }

    private void PlayTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.stopped += ResetTimeline;
            playableDirector.Play();
        }
        else
        {
            Debug.LogError("PlayableDirector is not assigned");
        }      
    }
    
    private void ResetTimeline(PlayableDirector director)
    {
        if(director == playableDirector)
        {
            playableDirector.time = 0;
            playableDirector.Evaluate();
            playableDirector.stopped -= ResetTimeline;
        }
    }
}
