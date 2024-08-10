using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuraction;
    [SerializeField] private float shakeMagnitude;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        //Saving the initial position of the camera
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }
    
    IEnumerator Shake()
    {
        //Setting up a local variable to control the shakeduration
        float elapsedTime = 0;

        //While the elapsedTime is lower than the shake duration
        while (elapsedTime < shakeDuraction)
        {
            //Move the camera according with the radion setted up
            //Increase the variable value
            //As soon as the variable value be like the shakeduration, wait the end of frame to get out
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        //Reseting the camera position to the initial position
        transform.position = initialPosition;
    }
}
