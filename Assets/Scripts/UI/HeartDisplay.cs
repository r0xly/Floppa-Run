using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public Image HeartIcon;
    private Image[] HeartIcons;

    void Start()
    {
        HeartIcons = new Image[GameLoop.MaxHealth];

        for (int i = 0; i < GameLoop.MaxHealth; i++) {
            var heart = Instantiate(HeartIcon);
            heart.transform.SetParent(transform, false);
            HeartIcons[i] = heart;
        }
    }

    void Update() {
        for (int i = 0; i < GameLoop.MaxHealth; i++) {
            HeartIcons[i].color = i < GameLoop.Health ? Color.white : Color.black;
        }
    }

}
