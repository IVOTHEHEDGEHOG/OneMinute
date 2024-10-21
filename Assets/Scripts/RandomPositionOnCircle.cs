using UnityEngine;

public class RandomPositionOnCircle : MonoBehaviour
{
    public float radius = 5.0f;              // Raio do círculo
    public float checkRadius = 0.5f;         // Raio para verificar colisões
    public LayerMask triggerLayer;            // Layer para verificar triggers

    private void Start()
    {
        SetRandomPosition();
    }

    private void SetRandomPosition()
    {
        Vector3 newPosition = Vector3.zero;

        // Tentar encontrar uma posição válida
        int attempts = 0;
        bool positionFound = false;

        while (!positionFound && attempts < 100)
        {
            attempts++;

            // Gera um ângulo aleatório em radianos
            float randomAngle = Random.Range(0f, 2 * Mathf.PI);

            // Calcula a nova posição com base no ângulo e no raio
            newPosition = new Vector3(
                radius * Mathf.Cos(randomAngle),  // Coordenada X
                radius * Mathf.Sin(randomAngle),
                0f
            );

            // Verifica se há um trigger na nova posição
            if (!Physics.CheckSphere(newPosition, checkRadius, triggerLayer))
            {
                positionFound = true; // Posição válida encontrada
            }
        }

        // Se uma posição válida foi encontrada, define a nova posição do GameObject
        if (positionFound)
        {
            transform.position = newPosition;
        }
        else
        {
            Debug.LogWarning("Não foi possível encontrar uma posição válida após 100 tentativas.");
        }
    }
}