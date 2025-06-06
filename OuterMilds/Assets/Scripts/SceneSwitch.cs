using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    public void SwitchScene(int index) => SceneManager.LoadScene(index);

    public void QuitGame() => Application.Quit();
}
