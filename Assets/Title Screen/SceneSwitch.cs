using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene(0);
    }
}
