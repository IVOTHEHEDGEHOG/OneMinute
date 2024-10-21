using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip musicClip;  // O clipe de áudio a ser tocado
    private AudioSource audioSource;

    private void Awake()
    {
        // Verifica se já existe uma instância deste objeto
        if (FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(gameObject); // Destroi o objeto se já houver uma instância
            return;
        }

        // Faz este objeto não ser destruído ao carregar uma nova cena
        DontDestroyOnLoad(gameObject);

        // Adiciona e configura o componente AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true; // Define para repetir a música
        audioSource.Play(); // Inicia a reprodução da música
    }
}