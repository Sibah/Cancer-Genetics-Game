using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData
{
    public string questionText;
    public Sprite questionImage;
    public int correctCount;
    public AnswerData[] answers;
}
