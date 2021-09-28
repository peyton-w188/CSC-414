using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable_Enable : MonoBehaviour
{
    DroneMovement myScript;



    void Start()
    {
        myScript = gameObject.GetComponent<DroneMovement>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            if (!myScript.enabled)
            {
                myScript.enabled = true;

                var animators = gameObject.GetComponentsInChildren<Animator>();
                for (var animatorIndex = 0; animatorIndex < animators.Length; animatorIndex++)
                {
                    animators[animatorIndex].enabled = true;
                }
            }
            else
            {
                myScript.enabled = false;

                var animators = gameObject.GetComponentsInChildren<Animator>();
                for (var animatorIndex = 0; animatorIndex < animators.Length; animatorIndex++)
                {
                    animators[animatorIndex].enabled = false;
                }
            }
        }
    }
}
