using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenu : MonoBehaviour
{
    public GameObject battleMenu;
    private float timeRemaining = 10;
    private bool timerIsRunning = false;
    private float numOfRounds = 0;
    private float numRoundsWonPlayer = 0;
    private float numRoundsWonOpponent = 0;
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
    public GameObject opponentImage;
    public float keysCounter = 0;
    public TMP_InputField input;
    private int firstNumber = 0;
    private int secondNumber = 0;
    private int guessedNumberByOpponent = 0;
    private int answer = 0;
    private int userAnswer = -1;
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
    public Button resetButton;
    public Movement movementScript;
    public Sprite[] spritesFaces;
    public bool RedKidBattle = false;
    public bool wonOverRedKid = false;
    public bool yellowHairKidBattle = false;
    public bool wonOverYellowHairKid = false;
    public bool FarmerBattle = false;
    public bool wonOverFarmer = false;


    // Start is called before the first frame update
    void Start()
    {
        battleMenu.SetActive(false);
        timerIsRunning = false;
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
        resetButton.onClick.AddListener(OnResetButton);
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
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        if (timeRemaining == 0)
        {
            guessedNumberByOpponent = Random.Range(answer - 1, answer + 1);
            if (userAnswer == answer)
            {
                playerImage.GetComponent<Image>().sprite = spritesFaces[1];
                if (winSquarePlayer1.GetComponent<RawImage>().color == Color.white)
                {
                    winSquarePlayer1.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonPlayer++;
                }
                else if (winSquarePlayer2.GetComponent<RawImage>().color == Color.white)
                {
                    winSquarePlayer2.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonPlayer++;
                }
                else if (winSquarePlayer3.GetComponent<RawImage>().color == Color.white)
                {
                    winSquarePlayer3.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonPlayer++;
                }
            }
            else if (userAnswer != answer)
            {
                playerImage.GetComponent<Image>().sprite = spritesFaces[2];
                if (winSquarePlayer1.GetComponent<RawImage>().color == Color.white)
                {
                    winSquarePlayer1.GetComponent<RawImage>().color = Color.red;
                }
                else if (winSquarePlayer2.GetComponent<RawImage>().color == Color.white)
                {
                    winSquarePlayer2.GetComponent<RawImage>().color = Color.red;
                }
                else if (winSquarePlayer3.GetComponent<RawImage>().color == Color.white)
                {
                    winSquarePlayer3.GetComponent<RawImage>().color = Color.red;
                }
            }
            if (guessedNumberByOpponent == answer && RedKidBattle == true)
            {
                opponentImage.GetComponent<Image>().sprite = spritesFaces[4];

                if (winSquareOpponent1.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent1.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonOpponent++;
                }
                else if (winSquareOpponent2.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent2.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonOpponent++;
                }
                else if (winSquareOpponent3.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent3.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonOpponent++;
                }
            }
            else if(guessedNumberByOpponent != answer && RedKidBattle == true)
            {
                opponentImage.GetComponent<Image>().sprite = spritesFaces[5];

                if (winSquareOpponent1.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent1.GetComponent<RawImage>().color = Color.red;
                }
                else if (winSquareOpponent2.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent2.GetComponent<RawImage>().color = Color.red;
                }
                else if (winSquareOpponent3.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent3.GetComponent<RawImage>().color = Color.red;
                }
            }
            if (guessedNumberByOpponent == answer && yellowHairKidBattle == true)
            {
                opponentImage.GetComponent<Image>().sprite = spritesFaces[7];

                if (winSquareOpponent1.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent1.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonOpponent++;
                }
                else if (winSquareOpponent2.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent2.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonOpponent++;
                }
                else if (winSquareOpponent3.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent3.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonOpponent++;
                }
            }
            else if(guessedNumberByOpponent != answer && yellowHairKidBattle == true)
            {
                opponentImage.GetComponent<Image>().sprite = spritesFaces[8];

                if (winSquareOpponent1.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent1.GetComponent<RawImage>().color = Color.red;
                }
                else if (winSquareOpponent2.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent2.GetComponent<RawImage>().color = Color.red;
                }
                else if (winSquareOpponent3.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent3.GetComponent<RawImage>().color = Color.red;
                }
            }
            if (guessedNumberByOpponent == answer && FarmerBattle == true)
            {
                opponentImage.GetComponent<Image>().sprite = spritesFaces[10];

                if (winSquareOpponent1.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent1.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonOpponent++;
                }
                else if (winSquareOpponent2.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent2.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonOpponent++;
                }
                else if (winSquareOpponent3.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent3.GetComponent<RawImage>().color = Color.green;
                    numRoundsWonOpponent++;
                }
            }
            else if (guessedNumberByOpponent != answer && FarmerBattle == true)
            {
                opponentImage.GetComponent<Image>().sprite = spritesFaces[11];

                if (winSquareOpponent1.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent1.GetComponent<RawImage>().color = Color.red;
                }
                else if (winSquareOpponent2.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent2.GetComponent<RawImage>().color = Color.red;
                }
                else if (winSquareOpponent3.GetComponent<RawImage>().color == Color.white)
                {
                    winSquareOpponent3.GetComponent<RawImage>().color = Color.red;
                }
            }
            if (RedKidBattle == true)
            {
                if (numOfRounds < 3)
                {
                    playerTitle.GetComponent<TextMeshProUGUI>().color = Color.white;
                    timeRemaining = 10;
                    input.text = "";
                    userAnswer = -1;
                    numOfRounds++;
                    firstNumber = Random.Range(0, 11);
                    secondNumber = Random.Range(0, 11);
                    answer = firstNumber + secondNumber;
                    factor1.text = firstNumber.ToString();
                    factor2.text = secondNumber.ToString();
                    timerIsRunning = true;
                }
                else
                {
                    input.text = "";
                    userAnswer = -1;
                }
                
            }
            if (yellowHairKidBattle == true)
            {
                if (numOfRounds < 3)
                {
                    playerTitle.GetComponent<TextMeshProUGUI>().color = Color.white;
                    timeRemaining = 10;
                    input.text = "";
                    userAnswer = -1;
                    numOfRounds++;
                    firstNumber = Random.Range(5, 11);
                    secondNumber = Random.Range(0, 6);
                    answer = firstNumber - secondNumber;
                    factor1.text = firstNumber.ToString();
                    factor2.text = secondNumber.ToString();
                    timerIsRunning = true;
                }
                else
                {
                    input.text = "";
                    userAnswer = -1;
                }

            }
            if (FarmerBattle == true)
            {
                if (numOfRounds < 3)
                {
                    if (numOfRounds == 0)
                    {
                        playerTitle.GetComponent<TextMeshProUGUI>().color = Color.white;
                        timeRemaining = 10;
                        input.text = "";
                        userAnswer = -1;
                        numOfRounds++;
                        firstNumber = Random.Range(10, 21);
                        secondNumber = Random.Range(0, 11);
                        answer = firstNumber - secondNumber;
                        symbol.text = "-";
                        factor1.text = firstNumber.ToString();
                        factor2.text = secondNumber.ToString();
                        timerIsRunning = true;
                    }
                    else
                    {
                        playerTitle.GetComponent<TextMeshProUGUI>().color = Color.white;
                        timeRemaining = 10;
                        input.text = "";
                        userAnswer = -1;
                        numOfRounds++;
                        firstNumber = Random.Range(0, 21);
                        secondNumber = Random.Range(0, 21);
                        answer = firstNumber + secondNumber;
                        symbol.text = "+";
                        factor1.text = firstNumber.ToString();
                        factor2.text = secondNumber.ToString();
                        timerIsRunning = true;
                    }
                       
                }
                else
                {
                    input.text = "";
                    userAnswer = -1;
                }

            }

        }

        if (numOfRounds == 3 && RedKidBattle == true)
        {
            numOfRounds++;
            timerIsRunning = false;
            
            if(numRoundsWonPlayer > numRoundsWonOpponent)
            {
                wonOverRedKid = true;
                RedKidBattle = false;
                keysCounter++;
                keyText.text = keysCounter.ToString();
                movementScript.speed = 5;
                Debug.Log("YOU Win");
            }
            else
            {
                movementScript.speed = 5;
                Debug.Log("YOU LOSE!");

            }
            
        }
        else if (numOfRounds == 3 && yellowHairKidBattle == true)
        {
            numOfRounds++;
            timerIsRunning = false;

            if (numRoundsWonPlayer > numRoundsWonOpponent)
            {
                wonOverYellowHairKid = true;
                yellowHairKidBattle = false;
                keysCounter++;
                keyText.text = keysCounter.ToString();
                movementScript.speed = 5;
                Debug.Log("YOU Win");
            }
            else
            {
                movementScript.speed = 5;
                Debug.Log("YOU LOSE!");

            }

        }
        else if (numOfRounds == 3 && FarmerBattle == true)
        {
            numOfRounds++;
            timerIsRunning = false;

            if (numRoundsWonPlayer > numRoundsWonOpponent)
            {
                wonOverFarmer = true;
                FarmerBattle = false;
                keysCounter++;
                keyText.text = keysCounter.ToString();
                movementScript.speed = 5;
                Debug.Log("YOU Win");
            }
            else
            {
                movementScript.speed = 5;
                Debug.Log("YOU LOSE!");

            }

        }

    }
    void OnClick0()
    {
        userAnswer = 0;
        input.text = input.text + userAnswer.ToString();
    }
    void OnClick1()
    {
        userAnswer = 1;
        input.text = input.text + userAnswer.ToString();

    }
    void OnClick2()
    {
        userAnswer = 2;
        input.text = input.text + userAnswer.ToString();
    }
    void OnClick3()
    {
        userAnswer = 3;
        input.text = input.text + userAnswer.ToString();
    }
    void OnClick4()
    {
        userAnswer = 4;
        input.text = input.text + userAnswer.ToString();
    }
    void OnClick5()
    {
        userAnswer = 5;
        input.text = input.text + userAnswer.ToString();
    }
    void OnClick6()
    {
        userAnswer = 6;
        input.text = input.text + userAnswer.ToString();
    }
    void OnClick7()
    {
        userAnswer = 7;
        input.text = input.text + userAnswer.ToString();
    }
    void OnClick8()
    {
        userAnswer = 8;
        input.text = input.text + userAnswer.ToString();
    }
    void OnClick9()
    {
        userAnswer = 9;
        input.text = input.text + userAnswer.ToString();
    }
    void OnEnterButon()
    {
        userAnswer = int.Parse(input.text);
        playerTitle.GetComponent<TextMeshProUGUI>().color = Color.green;

    }
    void OnResetButton()
    {
        input.text = "";
        userAnswer = -1;
        playerTitle.GetComponent<TextMeshProUGUI>().color = Color.white;

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
        if (collision.gameObject.tag == "redKid" && wonOverRedKid == false)
        {
            RedKidBattle = true;
            movementScript.speed = 0;
            numOfRounds = 0;
            numRoundsWonOpponent = 0;
            numRoundsWonPlayer = 0;
            input.text = "";
            battleMenu.SetActive(true);
            timeRemaining = 10;
            timerIsRunning = true;
            firstNumber = Random.Range(0, 11);
            secondNumber = Random.Range(0, 11);
            answer = firstNumber + secondNumber;
            factor1.text = firstNumber.ToString();
            factor2.text = secondNumber.ToString();
            symbol.text = "+";
            playerImage.GetComponent<Image>().sprite = spritesFaces[0];
            opponentImage.GetComponent<Image>().sprite = spritesFaces[3];
            winSquarePlayer1.GetComponent<RawImage>().color = Color.white;
            winSquarePlayer2.GetComponent<RawImage>().color = Color.white;
            winSquarePlayer3.GetComponent<RawImage>().color = Color.white;
            winSquareOpponent1.GetComponent<RawImage>().color = Color.white;
            winSquareOpponent2.GetComponent<RawImage>().color = Color.white;
            winSquareOpponent3.GetComponent<RawImage>().color = Color.white;
            playerTitle.GetComponent<TextMeshProUGUI>().color = Color.white;
            npcTitle.GetComponent<TextMeshProUGUI>().color = Color.white;
            npcTitle.GetComponent<TextMeshProUGUI>().text = "Jeremiah";
           
        }
        if (collision.gameObject.tag == "yellowKid" && keysCounter == 1 && wonOverYellowHairKid == false)
        {
            yellowHairKidBattle = true;
            movementScript.speed = 0;
            numOfRounds = 0;
            input.text = "";
            numRoundsWonOpponent = 0;
            numRoundsWonPlayer = 0;
            battleMenu.SetActive(true);
            timeRemaining = 10;
            timerIsRunning = true;
            firstNumber = Random.Range(5, 11);
            secondNumber = Random.Range(0, 6);
            answer = firstNumber - secondNumber;
            factor1.text = firstNumber.ToString();
            factor2.text = secondNumber.ToString();
            symbol.text = "-";
            playerImage.GetComponent<Image>().sprite = spritesFaces[0];
            opponentImage.GetComponent<Image>().sprite = spritesFaces[6];
            winSquarePlayer1.GetComponent<RawImage>().color = Color.white;
            winSquarePlayer2.GetComponent<RawImage>().color = Color.white;
            winSquarePlayer3.GetComponent<RawImage>().color = Color.white;
            winSquareOpponent1.GetComponent<RawImage>().color = Color.white;
            winSquareOpponent2.GetComponent<RawImage>().color = Color.white;
            winSquareOpponent3.GetComponent<RawImage>().color = Color.white;
            playerTitle.GetComponent<TextMeshProUGUI>().color = Color.white;
            npcTitle.GetComponent<TextMeshProUGUI>().color = Color.white;
            npcTitle.GetComponent<TextMeshProUGUI>().text = "Steven";
        }
        if (collision.gameObject.tag == "Farmer" &&  keysCounter == 2 && wonOverFarmer == false)
        {
            FarmerBattle = true;
            movementScript.speed = 0;
            numOfRounds = 0;
            numRoundsWonOpponent = 0;
            numRoundsWonPlayer = 0;
            battleMenu.SetActive(true);
            timeRemaining = 10;
            timerIsRunning = true;
            firstNumber = Random.Range(0, 21);
            secondNumber = Random.Range(0, 21);
            answer = firstNumber + secondNumber;
            factor1.text = firstNumber.ToString();
            factor2.text = secondNumber.ToString();
            symbol.text = "+";
            playerImage.GetComponent<Image>().sprite = spritesFaces[0];
            opponentImage.GetComponent<Image>().sprite = spritesFaces[9];
            winSquarePlayer1.GetComponent<RawImage>().color = Color.white;
            winSquarePlayer2.GetComponent<RawImage>().color = Color.white;
            winSquarePlayer3.GetComponent<RawImage>().color = Color.white;
            winSquareOpponent1.GetComponent<RawImage>().color = Color.white;
            winSquareOpponent2.GetComponent<RawImage>().color = Color.white;
            winSquareOpponent3.GetComponent<RawImage>().color = Color.white;
            playerTitle.GetComponent<TextMeshProUGUI>().color = Color.white;
            npcTitle.GetComponent<TextMeshProUGUI>().color = Color.white;
            npcTitle.GetComponent<TextMeshProUGUI>().text = "Farmer";

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        battleMenu.SetActive(false);
        
    }

}
