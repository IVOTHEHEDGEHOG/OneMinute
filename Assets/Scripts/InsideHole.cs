using System;
using System.Linq;
using UnityEngine;

public class InsideHole : MonoBehaviour
{
    public static int holes;
    public GameObject smoke;
    public Transform target;  // O transform que você está verificando
    public float threshold = 5.0f;  // Distância limite

    private void OnEnable()
    {
        holes++;
    }

    private void OnDisable()
    {
        holes--;
    }

    private void FixedUpdate()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance < threshold)
            {
                ExecuteMethod();
            }
        }
    }

    private void ExecuteMethod()
    {
        if (holes == 1)
        {
            ChallengeTimer.OnWin();
            Destroy(target);
        }
        else
        {
            target.position = Vector3.zero;
        }
        
    }
}
