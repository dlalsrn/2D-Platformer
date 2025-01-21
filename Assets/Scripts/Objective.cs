using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    public string nextLevel;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            PlayerPrefs.SetInt(nextLevel, 1); // 다음 레벨이 unlock됐다는 정보를 저장
            SceneManager.LoadScene(nextLevel);
        }
    }
}
