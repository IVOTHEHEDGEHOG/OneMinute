using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button game1;
    [SerializeField] private Button game2;
    [SerializeField] private Button game3;

    private void OnEnable()
    {
        game1.onClick.AddListener(OpenGame1);
        game2.onClick.AddListener(OpenGame2);
        game3.onClick.AddListener(OpenGame3);
    }

    private void OnDisable()
    {
        game1.onClick.RemoveAllListeners();
        game2.onClick.RemoveAllListeners();
        game3.onClick.RemoveAllListeners();
    }
    
    private void OpenGame1() =>  SceneManager.LoadScene("Game1");
    private void OpenGame2() => SceneManager.LoadScene("Game2");
    private void OpenGame3() => SceneManager.LoadScene("Game3");
}
