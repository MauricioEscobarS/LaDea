using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHud : MonoBehaviour
{
    [SerializeField]
    private Text currentLevelText;
    
    public void UpdateLevel(int currentLevel)
    {
        currentLevelText.text = currentLevel.ToString();
    }
}
