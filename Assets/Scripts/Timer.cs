using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour{
    
    public float timeRemaining = 0;

    void Update()
    {
        if (timeRemaining >= 0)
        {
            timeRemaining += Time.deltaTime;
        }
    }
}
