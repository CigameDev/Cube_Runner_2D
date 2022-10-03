using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text textScore;
    public GameObject panelGameover;

    public void SetScoreText(string txt)
    {
        if(textScore != null)
        {
            textScore.text = txt;
        }    
    }

    public void ShowGameOverPanel(bool state)
    {
        panelGameover.SetActive(state);
    }    
}
