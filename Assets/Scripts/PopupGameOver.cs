using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class PopupGameOver : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Score;

    [SerializeField]
    private TextMeshProUGUI MyScore;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        if (null != Score && null != MyScore)
        {
            string strtext = "score : ";

            strtext += Score.text;

            MyScore.text = strtext;
        }
    }

    public void OnClickedRetryBtn()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickedExitBtn()
    {
        SceneManager.LoadScene(0);
    }
}
