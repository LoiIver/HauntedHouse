using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MyDefaultTrackableEventHandler : DefaultTrackableEventHandler
{
    protected override void OnTrackingFound()
    {
        Debug.Log("OnTrackingFound!!!!");
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }

        // SOLUTION
        if (mTrackableBehaviour.gameObject.GetComponentInChildren<AudioSource>() != null)
        {
            mTrackableBehaviour.gameObject.GetComponentInChildren<AudioSource>().Play();
        }
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }


    protected override void OnTrackingLost()
    {
        Debug.Log("OnTrackingLost!!!!");
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }

        // SOLUTION
        if (mTrackableBehaviour.gameObject.GetComponentInChildren<AudioSource>() != null)
        {
            mTrackableBehaviour.gameObject.GetComponentInChildren<AudioSource>().Stop();
        }
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
    }
}
