using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurveyController : MonoBehaviour
{
    public TextMeshProUGUI text;
    [TextArea] public string[] questions;
    private int progress;

    private void Start() {
        text.text = questions[progress];
    }

    public void UpdateQuestion(bool answer)
    {}
}
