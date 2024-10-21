using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private string targetScene;
    [SerializeField] private bool sceneIsSelf;
    
    private void Start() => button.onClick.AddListener(ButtonPressed);
    private void ButtonPressed() => SceneManager.LoadScene(sceneIsSelf ? SceneManager.GetActiveScene().name : targetScene);
}
