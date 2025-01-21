using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameButton : MonoBehaviour
{
    Button button;
    public List<Button> buttons = new List<Button>();

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Scenes/Level1");
        });

        for (int i = 0; i < buttons.Count; i++) {
            // 열린 스테이지면 버튼이 활성화, 아니면 비활성화
            buttons[i].interactable = (PlayerPrefs.GetInt($"Scenes/Level{i + 2}") == 1 ? true : false);
        }
    }
}
