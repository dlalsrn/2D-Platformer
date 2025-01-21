using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHealth : MonoBehaviour
{
    PlayerController player;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public List<Image> hearts = new List<Image>();

    void Start() {
        player = FindObjectOfType<PlayerController>();
    }

    void Update() {
        for (int i = 0; i < hearts.Count; i++) {
            hearts[i].sprite = (i < player.health ? fullHeart : emptyHeart);
        }
    }
}
