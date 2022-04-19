using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    private Text TextObject;

    void Start() {
        this.TextObject = transform.GetComponent<Text>();
    }

    void Update()
    {
        this.TextObject.text = Mathf.Floor(GameLoop.Score).ToString();
    }
}
