using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timeRemainingDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Text questionDisplayText;
    public Image questionDisplayImage;
    public GameObject questionImage;

    public Transform answerButtonParent;
    public Text scoreDisplayText;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;

    private bool isRoundActive;
    public float timeRemaining;
    private float questionTimer;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();
    public List<AnswerData> correctAnswers = new List<AnswerData>();

    private List<int> questionIndexesChosen = new List<int>();
    private int qNumber;

    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;
        questionTimer = 50;

        UpdateTimeRemainingDisplay();

        playerScore = 0;
        questionIndex = 0;
        qNumber = 0;

        ShowQuestion();
        isRoundActive = true;

    }

    // Chooses random questions from questionPool.
    void ChooseQuestion()
    {
        bool questionChosen = false;

        while (questionChosen != true)
        {
            int random = Random.Range(0, questionPool.Length);

            if (!questionIndexesChosen.Contains(random))
            {
                questionIndexesChosen.Add(random);
                questionIndex = random;
                questionChosen = true;
            }
        }

    }

    // Displays new question from questionData. Removes old answerButtons and creates new ones according to how many answers are there.
    private void ShowQuestion()
    {
        RemoveAnswerButton();
        ChooseQuestion();
        QuestionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText;

        if(questionData.questionImage == null)
        {
            questionImage.SetActive(false);
        } else
        {
            questionImage.SetActive(true);
            questionDisplayImage.sprite = questionData.questionImage;
        }

        // This randomizes the order of answers
        System.Random rnd = new System.Random();
        var answersInRandomOrder = questionData.answers.OrderBy(x => rnd.Next()).ToArray();

        for (int i = 0; i < answersInRandomOrder.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            answerButtonGameObject.transform.localScale = Vector3.one;

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(answersInRandomOrder[i]);

            // Add all correct answers to list
            if (answerButton.GetComponent<AnswerButton>().answerData.isCorrect)
            {
                correctAnswers.Add(answersInRandomOrder[i]);
            }
        }
    }

    // This removes old answerButtons.
    private void RemoveAnswerButton()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    // Tests if the clicked answer is correct and adds the points. Updates the score text. Checks if there are more questions to show or ends the round.
    // Also gives point by remaining questionTime. If correct answer is pressed after 20 seconds have passed then it just gives 10 points.
    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            if (questionTimer > 20)
            {
                playerScore += Mathf.FloorToInt(questionTimer);
            }
            else
            {
                playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            }
            scoreDisplayText.text = "Score: " + playerScore.ToString();
            questionTimer = 50;
        }
        else
        {
            timeRemaining = timeRemaining - 5f;
        }
        
        questionTimer = 50;

        if (qNumber + 1 < questionPool.Length)
        {
            qNumber++;
            ShowQuestion();
        } else
        {
            EndRound();
        }

    }

    public void EndRound()
    {
        isRoundActive = false;
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

    void Update()
    {
        if (isRoundActive)
        {
            questionTimer -= Time.deltaTime;
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0f)
            {
                EndRound();
            }
        }
    }
}
