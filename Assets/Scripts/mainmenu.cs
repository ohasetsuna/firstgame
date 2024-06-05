using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game"); // Oyunun sahnesinin adı
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}