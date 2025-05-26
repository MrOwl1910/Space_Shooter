using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void StartingMENU()
    {
        SceneManager.LoadScene(0);
    }
   public void QuitGame()
   {
        Application.Quit();
        Debug.Log("YOU Are Out");
   }
}
