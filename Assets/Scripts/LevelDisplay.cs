using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    public TMP_Text text;

    public void SetLevel(int level)
    {
        text.SetText("Level: " + level);
    }
}
