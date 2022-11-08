using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenuYellowHairKid : MonoBehaviour
{
    public GameObject battleMenu;
    private float timeRemaining = 10;
    private bool timerIsRunning = false;
    private float timeForWaiting = 0;
    private bool timeForWaitingIsActive = false;
    private float numRoundsWonPlayer = 0;
    private float numRoundsWonOpponent = 0;
    private float numOfRounds = 0;
    private bool playerTurn = false;
    private bool opponentTurn = false;
    private GameObject winSquarePlayer1;
    private GameObject winSquarePlayer2;
    private GameObject winSquarePlayer3;
    private GameObject winSquareOpponent1;
    private GameObject winSquareOpponent2;
    private GameObject winSquareOpponent3;
    private GameObject playerTitle;
    private GameObject npcTitle;
    public Text timeText;
    public TextMeshProUGUI factor1;
    public TextMeshProUGUI factor2;
    public TextMeshProUGUI symbol;
    public TextMeshProUGUI keyText;
    public GameObject playerImage;
    public Sprite playerImageNormal;
    public Sprite playerImageHappy;
    public Sprite playerImageSad;
    public GameObject opponentImage;
    public Sprite opponentImageNormal;
    public Sprite opponentImageHappy;
    public Sprite opponentImageSad;
    private float keysCounter = 0;
    public TMP_InputField input;
    private int firstNumber = 0;
    private int secondNumber = 0;
    private int guessedNumberByOpponent = 0;
    private int answer = 0;
    private int userAnswer = 0;
    public Button buttonNum0;
    public Button buttonNum1;
    public Button buttonNum2;
    public Button buttonNum3;
    public Button buttonNum4;
    public Button buttonNum5;
    public Button buttonNum6;
    public Button buttonNum7;
    public Button buttonNum8;
    public Button buttonNum9;
    public Button enterButton;
    public Movement movementScript;


    // Start is called before the first frame update
    void Start()
    {
        battleMenu.SetActive(false);
        timerIsRunning = false;
        timeForWaitingIsActive = false;
        enterButton.onClick.AddListener(OnEnterButon);
        buttonNum0.onClick.AddListener(OnClick0);
        buttonNum1.onClick.AddListener(OnClick1);
        buttonNum2.onClick.AddListener(OnClick2);
        buttonNum3.onClick.AddListener(OnClick3);
        buttonNum4.onClick.AddListener(OnClick4);
        buttonNum5.onClick.AddListener(OnClick5);
        buttonNum6.onClick.AddListener(OnClick6);
        buttonNum7.onClick.AddListener(OnClick7);
        buttonNum8.onClick.AddListener(OnClick8);
        buttonNum9.onClick.AddListener(OnClick9);
        winSquarePlayer1 = battleMenu.transform.Find("winSquarePlayer1").gameObject;
        winSquarePlayer2 = battleMenu.transform.Find("winSquarePlayer2").gameObject;
        winSquarePlayer3 = battleMenu.transform.Find("winSquarePlayer3").gameObject;
        winSquareOpponent1 = battleMenu.transform.Find("winSquareOpponent1").gameObject;
        winSquareOpponent2 = battleMenu.transform.Find("winSquareOpponent2").gameObject;
        winSquareOpponent3 = battleMenu.transform.Find("winSquareOpponent3").gameObject;
        playerTitle = battleMenu.transform.Find("PlayerTitle").gameObject;
        npcTitle = battleMenu.transform.Find("NPCTitle").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (timeForWaitingIsActive)
        {
            if (timeForWaiting > 0)
            {
                // Subtract seconds by 1 and display time as text
                timeForWaiting -= Time.deltaTime;

            }
            else
            {
                timeForWaiting = 0;
                timeForWaitingIsActive = false;
            }
        }
        

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Subtract seconds by 1 and display time as text
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);

            }
            else
            {
                // Time set to 0, timer turned off
                timeRemaining = 0;
                timerIsRunning = false;
                if (playerTurn == true && timeRemaining == 0)
                {
                    playerImage.GetComponent<Image>().sprite = playerImageSad;
                    if (winSquarePlayer1.GetComponent<RawImage>().color == Color.white)
                    {
                        winSquarePlayer1.GetComponent<RawImage>().color = Color.red;
                        firstNumber = Random.Range(5, 10);
                        secondNumber = Random.Range(0, 6);
                        answer = firstNumber - secondNumber;
                        factor1.text = firstNumber.ToString();
                        factor2.text = secondNumber.ToString();
                        timeRemaining = 20;
                        timerIsRunning = true;
                        timeForWaiting = Random.Range(5, 11);
                        timeForWaitingIsActive = true;
                        guessedNumberByOpponent = Random.Range(answer - 1, answer + 1);
                        playerTurn = false;
                        opponentTurn = true;
                    }
                    else if (winSquarePlayer2.GetComponent<RawImage>().color == Color.white)
                    {
                        winSquarePlayer2.GetComponent<RawImage>().color = Color.red;
                        firstNumber = Random.Range(5, 10);
                        secondNumber = Random.Range(0, 6);
                        answer = firstNumber - secondNumber;
                        factor1.text = firstNumber.ToString();
                        factor2.text = secondNumber.ToString();
                        timeRemaining = 20;
                        timerIsRunning = true;
                        timeForWaiting = Random.Range(5, 11);
                        timeForWaitingIsActive = true;
                        guessedNumberByOpponent = Random.Range(answer - 1, answer + 1);
                        playerTurn = false;
                        opponentTurn = true;
                    }
                    else if (winSquarePlayer3.GetComponent<RawImage>().color == Color.white)
                    {
                        winSquarePlayer3.GetComponent<RawImage>().color = Color.red;
                        firstNumber = Random.Range(5, 10);
                        secondNumber = Random.Range(0, 6);
                        answer = firstNumber - secondNumber;
                        factor1.text = firstNumber.ToString();
                        factor2.text = secondNumber.ToString();
                        timeRemaining = 20;
                        timerIsRunning = true;
                        timeForWaiting = Random.Range(5, 11);
                        timeForWaitingIsActive = true;
                        guessedNumberByOpponent = Random.Range(answer - 1, answer + 1);
                        playerTurn = false;
                        opponentTurn = true;
                    }
                }
   
            }
        }

        if(opponentTurn == true)
        {
            opponentImage.GetComponent<Image>().sprite = opponentImageNormal;
            if (timeForWaiting == 0)
            {
                if (guessedNumberByOpponent == answer)
                {
                    opponentImage.GetComponent<Image>().sprite = opponentImageHappy;
                    playerImage.GetComponent<Image>().sprite = playerImageNormal;
                    if (winSquareOpponent1.GetComponent<RawImage>().color == Color.white)
                    {
                        winSquareOpponent1.GetComponent<RawImage>().color = Color.green;
                        numRoundsWonOpponent += 1;
                        firstNumber = Random.Range(5, 10);
                        secondNumber = Random.Range(0, 6);
                        answer = firstNumber - secondNumber;
                        factor1.text = firstNumber.ToString();
                        factor2.text = secondNumber.ToString();
                        timeRemaining = 20;
                        numOfRounds++;
                        opponentTurn = false;
                        playerTurn = true;
                    }
                    else if (winSquareOpponent2.GetComponent<RawImage>().color == Color.white)
                    {
                        winSquareOpponent2.GetComponent<RawImage>().color = Color.green;
                        numRoundsWonOpponent += 1;
                        firstNumber = Random.Range(5, 10);
                        secondNumber = Random.Range(0, 6);
                        answer = firstNumber - secondNumber;
                        factor1.text = firstNumber.ToString();
                        factor2.text = secondNumber.ToString();
                        timeRemaining = 20;
                        numOfRounds++;
                        opponentTurn = false;
                        playerTurn = true;

                    }
                    else if (winSquareOpponent3.GetComponent<RawImage>().color == Color.white)
                    {
                        winSquareOpponent3.GetComponent<RawImage>().color = Color.green;
                        numRoundsWonOpponent += 1;
                        numOfRounds++;
                        opponentTurn = false;
                        playerTurn = false;

                    }

                }
                else
                {
                    opponentImage.GetComponent<Image>().sprite = opponentImageSad;
                    playerImage.GetComponent<Image>().sprite = playerImageNormal;
                    if (winSquareOpponent1.GetComponent<RawImage>().color == Color.white)
                    {
                        winSquareOpponent1.GetComponent<RawImage>().color = Color.red;
                        firstNumber = Random.Range(5, 10);
                        secondNumber = Random.Range(0, 6);
                        answer = firstNumber - secondNumber;
                        factor1.text = firstNumber.ToString();
                        factor2.text = secondNumber.ToString();
                        timeRemaining = 20;
                        numOfRounds++;
                        opponentTurn = false;
                        playerTurn = true;
                    }
                    else if (winSquareOpponent2.GetComponent<RawImage>().color == Color.white)
                    {
                        winSquareOpponent2.GetComponent<RawImage>().color = Color.red;
                        firstNumber = Random.Range(5, 10);
                        secondNumber = Random.Range(0, 6);
                        answer = firstNumber - secondNumber;
                        factor1.text = firstNumber.ToString();
                        factor2.text = secondNumber.ToString();
                        timeRemaining = 20;
                        numOfRounds++;
                        opponentTurn = false;
                        playerTurn = true;
                    }
                    else if (winSquareOpponent3.GetComponent<RawImage>().color == Color.white)
                    {
                        winSquareOpponent3.GetComponent<RawImage>().color = Color.red;
                        
                        numOfRounds++;
                        opponentTurn = false;
                        playerTurn = false;
                    }

                }
            }

        }
        if (playerTurn == true)
        {
            playerTitle.GetComponent<TextMeshProUGUI>().color = Color.green;

        }
        else
        {
            playerTitle.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        if (opponentTurn == true)
        {
            npcTitle.GetComponent<TextMeshProUGUI>().color = Color.green;

        }
        else
        {
            npcTitle.GetComponent<TextMeshProUGUI>().color = Color.white;

        }

        if (numOfRounds == 3)
        {
            numOfRounds++;
            timerIsRunning = false;
            
            if(numRoundsWonPlayer > numRoundsWonOpponent)
            {
                keysCounter++;
                keyText.text = keysCounter.ToString();
                movementScript.speed = 5;
                Debug.Log("NumOfROunds " + numOfRounds);
                Debug.Log("Rounds won for opponent " + numRoundsWonOpponent);
                Debug.Log("Rounds won for player " + numRoundsWonPlayer);
                Debug.Log("YOU Win");
                movementScript.GetComponent<BattleMenuYellowHairKid>().enabled = false;
                movementScript.GetComponent<BattleMenuFarmer>().enabled = true;

            }
            else
            {
                movementScript.speed = 5;
                Debug.Log("NumOfROunds " + numOfRounds);
                Debug.Log("Rounds won for opponent " + numRoundsWonOpponent);
                Debug.Log("Rounds won for player " + numRoundsWonPlayer);
                Debug.Log("YOU LOSE!");

            }
            
        }
        
    }
    void OnClick0()
    {
        userAnswer = 0;
        input.text = userAnswer.ToString();
    }
    void OnClick1()
    {
        userAnswer = 1;
        input.text = userAnswer.ToString();
        
    }
    void OnClick2()
    {
        userAnswer = 2;
        input.text = userAnswer.ToString();
        
    }
    void OnClick3()
    {
        userAnswer = 3;
        input.text = userAnswer.ToString();
        
    }
    void OnClick4()
    {
        userAnswer = 4;
        input.text = userAnswer.ToString();
        
    }
    void OnClick5()
    {
        userAnswer = 5;
        input.text = userAnswer.ToString();
        
    }
    void OnClick6()
    {
        userAnswer = 6;
        input.text = userAnswer.ToString();
        
    }
    void OnClick7()
    {
        userAnswer = 7;
        input.text = userAnswer.ToString();
       
    }
    void OnClick8()
    {
        userAnswer = 8;
        input.text = userAnswer.ToString();
        
    }
    void OnClick9()
    {
        userAnswer = 9;
        input.text = userAnswer.ToString();
        
    }
    void OnEnterButon()
    {
        if (playerTurn == true && numOfRounds < 3 && timeRemaining != 0)
        {
            userAnswer = int.Parse(input.text);
            if (userAnswer == answer)
            {
                playerImage.GetComponent<Image>().sprite = playerImageHappy;
                if (winSquarePlayer1.GetComponent<RawImage>().color == Color.white)
                {
                    winSquarePlayer1.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonPlayer += 1;
                    firstNumber = Random.Range(5, 10);
                    secondNumber = Random.Range(0, 6);
                    answer = firstNumber - secondNumber;
                    factor1.text = firstNumber.ToString();
                    factor2.text = secondNumber.ToString();
                    timeRemaining = 20;
                    timeForWaiting = Random.Range(5, 11);
                    timeForWaitingIsActive = true;
                    guessedNumberByOpponent = Random.Range(answer - 1, answer + 1);
                    playerTurn = false;
                    opponentTurn = true;
                }
                else if (winSquarePlayer2.GetComponent<RawImage>().color == Color.white)
                {
                    winSquarePlayer2.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonPlayer += 1;
                    firstNumber = Random.Range(5, 10);
                    secondNumber = Random.Range(0, 6);
                    answer = firstNumber - secondNumber;
                    factor1.text = firstNumber.ToString();
                    factor2.text = secondNumber.ToString();
                    timeRemaining = 20;
                    timeForWaiting = Random.Range(5, 11);
                    timeForWaitingIsActive = true;
                    guessedNumberByOpponent = Random.Range(answer - 1, answer + 1);
                    playerTurn = false;
                    opponentTurn = true;

                }
                else if (winSquarePlayer3.GetComponent<RawImage>().color == Color.white)
                {
                    winSquarePlayer3.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonPlayer += 1;
                    firstNumber = Random.Range(5, 10);
                    secondNumber = Random.Range(0, 6);
                    answer = firstNumber - secondNumber;
                    factor1.text = firstNumber.ToString();
                    factor2.text = secondNumber.ToString();
                    timeRemaining = 20;
                    timeForWaiting = Random.Range(5, 11);
                    timeForWaitingIsActive = true;
                    guessedNumberByOpponent = Random.Range(answer - 1, answer + 1);
                    playerTurn = false;
                    opponentTurn = true;

                }

            }
            else
            {
                playerImage.GetComponent<Image>().sprite = playerImageSad;
                if (winSquarePlayer1.GetComponent<RawImage>().color == Color.white)
                {
                    winSquarePlayer1.GetComponent<RawImage>().color = Color.red;
                    firstNumber = Random.Range(5, 10);
                    secondNumber = Random.Range(0, 6);
                    answer = firstNumber - secondNumber;
                    factor1.text = firstNumber.ToString();
                    factor2.text = secondNumber.ToString();
                    timeRemaining = 20;
                    timeForWaiting = Random.Range(5, 11);
                    timeForWaitingIsActive = true;
                    guessedNumberByOpponent = Random.Range(answer - 1, answer + 1);
                    playerTurn = false;
                    opponentTurn = true;
                }
                else if (winSquarePlayer2.GetComponent<RawImage>().color == Color.white)
                {
                    winSquarePlayer2.GetComponent<RawImage>().color = Color.red;
                    firstNumber = Random.Range(5, 10);
                    secondNumber = Random.Range(0, 6);
                    answer = firstNumber - secondNumber;
                    factor1.text = firstNumber.ToString();
                    factor2.text = secondNumber.ToString();
                    timeRemaining = 20;
                    timeForWaiting = Random.Range(5, 11);
                    timeForWaitingIsActive = true;
                    guessedNumberByOpponent = Random.Range(answer - 1, answer + 1);
                    playerTurn = false;
                    opponentTurn = true;
                }
                else if (winSquarePlayer3.GetComponent<RawImage>().color == Color.white)
                {
                    winSquarePlayer3.GetComponent<RawImage>().color = Color.red;
                    firstNumber = Random.Range(5, 10);
                    secondNumber = Random.Range(0, 6);
                    answer = firstNumber - secondNumber;
                    factor1.text = firstNumber.ToString();
                    factor2.text = secondNumber.ToString();
                    timeRemaining = 20;
                    timeForWaiting = Random.Range(5, 11);
                    timeForWaitingIsActive = true;
                    guessedNumberByOpponent = Random.Range(answer - 1, answer + 1);
                    playerTurn = false;
                    opponentTurn = true;
                }

            }
        }
            

    }
    void DisplayTime(float timeToDisplay)
    {
        // += 1 because we are counting down (half a second left shown as 1 second to user)
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}", seconds);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "yellowKid" && int.Parse(keyText.text) == 1 && movementScript.GetComponent<BattleMenuYellowHairKid>().enabled == true)
        {
            keysCounter = int.Parse(keyText.text);
            movementScript.speed = 0;
            numOfRounds = 0;
            numRoundsWonOpponent = 0;
            numRoundsWonPlayer = 0;
            battleMenu.SetActive(true);
            timeRemaining = 20;
            timerIsRunning = true;
            firstNumber = Random.Range(5, 10);
            secondNumber = Random.Range(0, 6);
            answer = firstNumber - secondNumber;
            factor1.text = firstNumber.ToString();
            factor2.text = secondNumber.ToString();
            symbol.text = "-";
            playerImage.GetComponent<Image>().sprite = playerImageNormal;
            opponentImage.GetComponent<Image>().sprite = opponentImageNormal;
            winSquarePlayer1.GetComponent<RawImage>().color = Color.white;
            winSquarePlayer2.GetComponent<RawImage>().color = Color.white;
            winSquarePlayer3.GetComponent<RawImage>().color = Color.white;
            winSquareOpponent1.GetComponent<RawImage>().color = Color.white;
            winSquareOpponent2.GetComponent<RawImage>().color = Color.white;
            winSquareOpponent3.GetComponent<RawImage>().color = Color.white;
            playerTitle.GetComponent<TextMeshProUGUI>().color = Color.white;
            npcTitle.GetComponent<TextMeshProUGUI>().color = Color.white;
            npcTitle.GetComponent<TextMeshProUGUI>().text = "Jhonny";
            opponentTurn = false; 
            playerTurn = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        battleMenu.SetActive(false);

    }

}
