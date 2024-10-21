using UnityEngine;

public class GyroscopeControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGyroEnabled;
    private Gyroscope gyro;

    // Sensibilidade da força
    public float forceMultiplier = 10f;

    void Start()
    {
        // Obtém o Rigidbody2D da bola
        rb = GetComponent<Rigidbody2D>();

        // Ativa o giroscópio do dispositivo
        isGyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        return false;
    }

    void FixedUpdate()
    {
        if (isGyroEnabled)
        {
            // Obtém os valores de rotação do giroscópio
            Vector3 gyroInput = gyro.rotationRateUnbiased;

            // Converte o input do giroscópio para adicionar força à bola
            Vector2 force = new Vector2(gyroInput.y, -gyroInput.x) * forceMultiplier;

            // Aplica a força no Rigidbody2D
            rb.AddForce(force);
        }
        else
        {
            Vector3 input = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            Vector2 force = new Vector2(input.x, input.y) * forceMultiplier;
            rb.AddForce(force);
        }
    }
}