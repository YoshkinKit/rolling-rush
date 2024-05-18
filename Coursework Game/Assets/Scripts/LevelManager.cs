using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Testing");
    }
}
