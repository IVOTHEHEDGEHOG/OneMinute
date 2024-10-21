using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    public GameObject smoke;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Vector3.Distance(transform.position, other.transform.position) < 0.2f)
        {
            Destroy(other.gameObject);
            Instantiate(smoke, transform.position, Quaternion.identity);
            
            if (FindObjectsOfType<GyroscopeControl>().Length == 1)
                ChallengeTimer.OnWin();
            
            Destroy(transform.parent.gameObject);
        }
            
    }
}
