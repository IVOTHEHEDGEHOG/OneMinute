using UnityEngine;

public class BreathingEffect : MonoBehaviour
{
    // Frequência da respiração (quantas vezes por segundo).
    public float frequency = 1.0f;
    // Amplitude da respiração (quanto o objeto cresce e diminui).
    public float amplitude = 0.1f;
    // Tamanho original do objeto.
    private Vector3 originalScale;

    void Start()
    {
        // Armazena o tamanho original do objeto.
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Calcula o fator de escala usando uma onda senoidal.
        float scale = 1.0f + Mathf.Sin(Time.time * frequency * Mathf.PI * 2.0f) * amplitude;
        // Ajusta o tamanho do objeto.
        transform.localScale = originalScale * scale;
    }
}