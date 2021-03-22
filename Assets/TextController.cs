using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public Slider input;
    public Text message;
    public void updateText()
    { 
        message.text = ((int)input.value).ToString();
    }
}
