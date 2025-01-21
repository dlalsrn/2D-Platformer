using UnityEngine;
using UnityEngine.UI;

public class HudKey : MonoBehaviour
{
    public Sprite fullKey;
    public Sprite emptyKey;
    PlayerController player;
    Key key;
    Image keyImage;

    void Start() {
        player = FindObjectOfType<PlayerController>();
        key = FindObjectOfType<Key>();
        keyImage = GetComponent<Image>();

        if (key == null) {
            gameObject.SetActive(false);
        }
    }

    void Update() {
        keyImage.sprite = (player.hasKey ? fullKey : emptyKey);
    }
}
