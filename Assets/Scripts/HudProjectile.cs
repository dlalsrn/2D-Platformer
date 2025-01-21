using UnityEngine;
using UnityEngine.UI;

public class HudProjectile : MonoBehaviour
{
    PlayerController player;
    Image image;

    void Start() {
        player = FindObjectOfType<PlayerController>();
        image = GetComponent<Image>();
    }

    void Update() {
        image.enabled = (player.hasProjectile ? true : false);
    }
}
