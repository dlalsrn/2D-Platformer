using UnityEngine;
using UnityEngine.SceneManagement;

public class HudManager : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Scenes/HUD", LoadSceneMode.Additive);
    }
}
