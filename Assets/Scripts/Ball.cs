using UnityEngine;

public class Ball : MonoBehaviour
{
    public ChallengeTimer timer;
    public GameObject pressShit;
    private Rigidbody2D rb;
    public float forceMultiplier = 10f;

    void Start()
    {
        // Obtém o Rigidbody2D do objeto
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Detecta quando o mouse ou a tela é clicada
        if (Input.GetMouseButtonDown(0))
        {
            if (rb.gravityScale == 0)
            {
                timer.StartTimer();
                rb.gravityScale = 1;
                pressShit.SetActive(false);
            }
            
            // Converte a posição do clique do mouse para a posição no mundo 2D
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calcula a direção oposta ao clique em relação à posição atual do objeto
            Vector2 direction = (rb.position - clickPosition).normalized;

            // Aplica a força na direção oposta
            rb.AddForce(direction * forceMultiplier, ForceMode2D.Impulse);
        }
    }
}