using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public Button startButton;

    void OnEnable()
    {
        startButton.onClick.AddListener(LoadScene);
    }

    void OnDisable()
    {
        startButton.onClick.RemoveAllListeners();
    }

    void LoadScene()
    {
        SceneManager.LoadScene("InGame");
    }
}