using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour { 

    public static int hole1 = 0;
    public static int hole2 = 0;
    public static int maxStrokes = 15;
    public static int strokes = maxStrokes;
    public Text curStrokes;
    public static int currentHole = 0;
    public static int par = 0;
    public Text curPar;

    
    void Start()
    {
        switch (DifficultyManager.Difficulty)
        {
            case DifficultyManager.Difficulties.easy:
                maxStrokes = 20;
                strokes = 20;
                break;
            case DifficultyManager.Difficulties.normal:
                maxStrokes = 15;
                strokes = 15;
                break;
            case DifficultyManager.Difficulties.hard:
                maxStrokes = 10;
                strokes = 10;
                break;
        }
    }

     
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "hole1")
        {
            currentHole = hole1;
            switch (DifficultyManager.Difficulty)
            {
                case DifficultyManager.Difficulties.easy:
                    par = 4 ;
                    break;
                case DifficultyManager.Difficulties.normal:
                    par = 2 ;
                    break;
                case DifficultyManager.Difficulties.hard:
                    par = 1 ;
                    break;
            }
        }
        else if (SceneManager.GetActiveScene().name == "hole2")
        {
            currentHole = hole2;
            switch (DifficultyManager.Difficulty)
            {
                case DifficultyManager.Difficulties.easy:
                    par = 4;
                    break;
                case DifficultyManager.Difficulties.normal:
                    par = 3;
                    break;
                case DifficultyManager.Difficulties.hard:
                    par = 2;
                    break;
            }
        
         
        }

        curStrokes.GetComponent<Text>().text = "Coups: " + currentHole.ToString() + "/" + maxStrokes.ToString();
        curPar.GetComponent<Text>().text = "Nombre Coups Idéale : " + par.ToString();
    }
}