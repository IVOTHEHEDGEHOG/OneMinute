using UnityEngine;

public class Deactivate : MonoBehaviour
{
    void Start()
    {
        Invoke("DesativarObjeto", 2f);
    }

    void DesativarObjeto()
    {
        gameObject.SetActive(false);
    }
}