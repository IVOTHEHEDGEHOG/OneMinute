using UnityEngine;

public class CheckDistance : MonoBehaviour
{
    public Transform target1; // Transform do alvo
    public Transform target2; // Transform do alvo
    public Transform target3; // Transform do alvo
    public float distanciaLimite = 5f; // Distância específica

    void Update()
    {
        if (target1 != null)
        {
            float distancia = Vector3.Distance(transform.position, target1.position);

            if (distancia > distanciaLimite)
            {
                ChallengeTimer.OnLose();
            }
        }
        
        if (target2 != null)
        {
            float distancia = Vector3.Distance(transform.position, target2.position);

            if (distancia > distanciaLimite)
            {
                ChallengeTimer.OnLose();
            }
        }
        
        if (target3 != null)
        {
            float distancia = Vector3.Distance(transform.position, target3.position);

            if (distancia > distanciaLimite)
            {
                ChallengeTimer.OnLose();
            }
        }
    }
}