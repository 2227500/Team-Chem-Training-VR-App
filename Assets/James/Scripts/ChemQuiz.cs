using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class ChemQuiz : MonoBehaviour
{

    public TMP_Text questionText;
    public TMP_Text feedbackText;
    public float fadeTime = 1.0f;  // The duration of the fade animation in seconds
    private Color originalColour;


    public TMP_Text textToChangeSize1;
    public TMP_Text textToChangeSize2;
    public TMP_Text textToChangeSize3;

    public Button quizStartButton;
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;

    private int currentQuestion = 0;

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;

    public AirTableTime timer;

    //public GameObject prefab5;
    //public GameObject prefab6;
    //public GameObject prefab7;
    //public GameObject prefab8;

    private Image imageComponentButton2;
    private Image imageComponentButton4;

    public float score;
    
    void Start()
    {
        // Get the TextMeshProUGUI component of the game object and store its original color
        originalColour = feedbackText.color;

        imageComponentButton4 = Button4.GetComponent<Image>();
        imageComponentButton2 = Button2.GetComponent<Image>();
    }

    public void CheckAnswer(int answer)
    {
        if (currentQuestion == 0 && answer == 1)
        {
            feedbackText.text = "";
            score = 0;
        }
        else if (currentQuestion == 1 && answer == 3)
        {
            feedbackText.text = "Correct!";
            score = score + 1;
        }
        else if (currentQuestion == 2 && answer == 1)
        {
            feedbackText.text = "Correct!";
            score = score + 1;
        }
        else if (currentQuestion == 3 && answer == 3)
        {
            feedbackText.text = "Correct!";
            score = score + 1;
        }
        else if (currentQuestion == 4 && answer == 1)
        {
            feedbackText.text = "Correct!";
            score = score + 1;
        }
        else if (currentQuestion == 5 && answer == 2)
        {
            feedbackText.text = "Correct!";
            score = score + 1;
        }
        else if (currentQuestion == 6 && answer == 3)
        {
            feedbackText.text = "Correct!";
            score = score + 1;
        }
        else if (currentQuestion == 7 && answer == 3)
        {
            feedbackText.text = "Correct!";
            score = score + 1;
        }
        else if (currentQuestion == 8 && answer == 3)
        {
            feedbackText.text = "Correct!";
            score = score + 1;
        }
        else if (currentQuestion == 9 && answer == 3)
        {
            feedbackText.text = "Correct!";
            score = score + 1;
        }
        else if (currentQuestion == 10 && answer == 3)
        {
            feedbackText.text = "Correct!";
            score = score + 1;
        }
        else if (currentQuestion == 11 && answer == 1)
        {
            feedbackText.text = "Correct!";
            score = score + 1;
        }
        else if (currentQuestion == 12 && answer == 3)
        {
            feedbackText.text = "Correct!";
            score = score + 1;
        }
        else if (currentQuestion == 13 && answer == 3)
        {
            feedbackText.text = "Correct!";
            score = score + 1;
        }
        else if (currentQuestion == 14 && answer == 1)
        {
            feedbackText.text = "Correct!";
            score = score + 1;
        }
        else
        {
            feedbackText.text = "Incorrect!";
        }

        currentQuestion++;

        // Hide the quiz panel after the final question
        if (currentQuestion > 14)
        {
            gameObject.SetActive(false);
            timer.ToggleTimer();
            timer.SavePlayerTime();
        }
        else
        {
            // Update the question text and answer options for the next question
            if (currentQuestion == 2)
            {
                StartCoroutine(FadeOut());

               prefab1 = Instantiate(prefab1, new Vector3(-3, 2, 5), Quaternion.identity);
               prefab2 = Instantiate(prefab2, new Vector3(-1, 1, 5), Quaternion.identity);
               prefab3 = Instantiate(prefab3, new Vector3(1, 3, 5), Quaternion.identity);
               prefab4 = Instantiate(prefab4, new Vector3(3, 4, 5), Quaternion.identity);

                questionText.text = "Question " + currentQuestion + ": Which of these components is the condenser?";
                Button1.GetComponentInChildren<TMP_Text>().text = "1";
                Button2.GetComponentInChildren<TMP_Text>().text = "2";
                Button3.GetComponentInChildren<TMP_Text>().text = "3";
                Button4.GetComponentInChildren<TMP_Text>().text = "4";
            }
            else if (currentQuestion == 3)
            {
                Destroy(prefab1);
                Destroy(prefab2);
                Destroy(prefab3);
                Destroy(prefab4);

                StartCoroutine(FadeOut());

                questionText.text = "Question " + currentQuestion + ": At the start of the experiment which valve do you not close?";
                Button1.GetComponentInChildren<TMP_Text>().text = "V12";
                Button2.GetComponentInChildren<TMP_Text>().text = "V5";
                Button3.GetComponentInChildren<TMP_Text>().text = "V4";
                Button4.GetComponentInChildren<TMP_Text>().text = "V8";
            }
            else if (currentQuestion == 4)
            {
                StartCoroutine(FadeOut());

                questionText.text = "Question " + currentQuestion + ": When you started P1 what did you set the feed flowrate to?";
                Button1.GetComponentInChildren<TMP_Text>().text = "60%";
                Button2.GetComponentInChildren<TMP_Text>().text = "75%";
                Button3.GetComponentInChildren<TMP_Text>().text = "50%";
                Button4.GetComponentInChildren<TMP_Text>().text = "40%";
            }
            else if (currentQuestion == 5)
            {
                StartCoroutine(FadeOut());

                questionText.text = "Question " + currentQuestion + ": What happens to the boiling point of a solvent as the pressure increases? ?";
                Button1.GetComponentInChildren<TMP_Text>().text = "The boiling point remains constant. ";
                Button2.GetComponentInChildren<TMP_Text>().text = "The boiling point gets higher. ";
                Button3.GetComponentInChildren<TMP_Text>().text = "The boiling point gets lower. ";
                Button4.GetComponentInChildren<TMP_Text>().text = "";
                imageComponentButton4.enabled = false;

            }
            else if (currentQuestion == 6)
            {
                StartCoroutine(FadeOut());

                questionText.text = "Question " + currentQuestion + ": What does BPE stand for? ";
                Button1.GetComponentInChildren<TMP_Text>().text = "Boiling Pressure Elevation.";
                Button2.GetComponentInChildren<TMP_Text>().text = "Boiling Point Evaporation. ";
                Button3.GetComponentInChildren<TMP_Text>().text = "Boiling Point Elevation. ";
                Button4.GetComponentInChildren<TMP_Text>().text = "";


            }
            else if (currentQuestion == 7)
            {
                StartCoroutine(FadeOut());

                questionText.text = "Question " + currentQuestion + ": Why are evaporators typically run under vacuum? ";
                Button1.GetComponentInChildren<TMP_Text>().text = "To reduce the temperature of boiling.";
                Button2.GetComponentInChildren<TMP_Text>().text = "To help remove non condensable gases. ";
                Button3.GetComponentInChildren<TMP_Text>().text = "Both of the above. ";
                Button4.GetComponentInChildren<TMP_Text>().text = "";
                

            }
            else if (currentQuestion == 8)
            {
                StartCoroutine(FadeOut());

                questionText.text = "Question " + currentQuestion + ": How are the tube surfaces in falling film evaporators heated to enhance evaporation? ";
                Button1.GetComponentInChildren<TMP_Text>().text = "Heaters at about 200°C.";
                Button2.GetComponentInChildren<TMP_Text>().text = "Heaters at just above 100°C. ";
                Button3.GetComponentInChildren<TMP_Text>().text = "Steam condensing at the outer wall. ";
                Button4.GetComponentInChildren<TMP_Text>().text = "";
               
            }
            else if (currentQuestion == 9)
            {
                StartCoroutine(FadeOut());

                questionText.text = "Question " + currentQuestion + ": Which of the following is not a type of evaporator? ";
                Button1.GetComponentInChildren<TMP_Text>().text = "Forced Circulation.";
                Button2.GetComponentInChildren<TMP_Text>().text = "Falling Film. ";
                Button3.GetComponentInChildren<TMP_Text>().text = "Gasketed. ";
                Button4.GetComponentInChildren<TMP_Text>().text = "";

            }
            else if (currentQuestion == 10)
            {
                StartCoroutine(FadeOut());

                questionText.text = "Question " + currentQuestion + ": Falling film evaporators are those in which evaporation occurs from the film interface with nucleate boiling at the wall. True or false?";
                Button1.GetComponentInChildren<TMP_Text>().text = "True.";
                Button2.GetComponentInChildren<TMP_Text>().text = " ";
                Button3.GetComponentInChildren<TMP_Text>().text = "False. ";
                Button4.GetComponentInChildren<TMP_Text>().text = "";
                imageComponentButton2.enabled = false;
                

            }
            else if (currentQuestion == 11)
            {
                StartCoroutine(FadeOut());

                questionText.text = "Question " + currentQuestion + ": What is the driving force that sets off evaporation? ";
                Button1.GetComponentInChildren<TMP_Text>().text = "Difference in partial pressure.";
                Button2.GetComponentInChildren<TMP_Text>().text = "Difference in concentration. ";
                Button3.GetComponentInChildren<TMP_Text>().text = "Difference in temperature. ";
                Button4.GetComponentInChildren<TMP_Text>().text = "";
                imageComponentButton2.enabled = true;

            }
            else if (currentQuestion == 12)
            {
                StartCoroutine(FadeOut());

                questionText.text = "Question " + currentQuestion + ": Falling film evaporators can be operated in _______________ ";
                Button1.GetComponentInChildren<TMP_Text>().text = "Co-current flow with vapour.";
                Button2.GetComponentInChildren<TMP_Text>().text = "Counter-flow with the vapour. ";
                Button3.GetComponentInChildren<TMP_Text>().text = "Both co-current and counter-current. ";
                Button4.GetComponentInChildren<TMP_Text>().text = "";

            }
            else if (currentQuestion == 13)
            {
                StartCoroutine(FadeOut());

                questionText.text = "Question " + currentQuestion + ": The amount of heat transferred through the evaporator wall is actually equal to which one of the following? ";
                Button1.GetComponentInChildren<TMP_Text>().text = "The heat carried by the vapour leaving the evaporator.";
                Button2.GetComponentInChildren<TMP_Text>().text = "The total heat of increasing the feed temperature to boiling point.";
                Button3.GetComponentInChildren<TMP_Text>().text = "The total heat of increasing the feed temperature to boiling point and the heat required form the vapour. ";
                Button4.GetComponentInChildren<TMP_Text>().text = "";
                textToChangeSize1.fontSize = 20;
                textToChangeSize2.fontSize = 20;
                textToChangeSize3.fontSize = 16;

            }
            else if (currentQuestion == 14)
            {
                StartCoroutine(FadeOut());

                questionText.text = "Question " + currentQuestion + ": In relation to evaporators what is the steam economy? ";
                Button1.GetComponentInChildren<TMP_Text>().text = "The steam economy is defined as the ratio between the solvent evaporated and the steam introduced into the system. ";
                Button2.GetComponentInChildren<TMP_Text>().text = "The steam economy is the amount of steam used in the system. ";
                Button3.GetComponentInChildren<TMP_Text>().text = "The steam economy is the amount of steam used in the system minus the amount of solvent evaporated. ";
                Button4.GetComponentInChildren<TMP_Text>().text = "";
                textToChangeSize1.fontSize = 16;
                textToChangeSize2.fontSize = 16;
            }
            else if (currentQuestion == 1)
            {
                Instantiate(prefab1, new Vector3(0, 2, 0), Quaternion.identity);
                Instantiate(prefab2, new Vector3(0, 1, 0), Quaternion.identity);
                Instantiate(prefab3, new Vector3(0, 3, 0), Quaternion.identity);
                Instantiate(prefab4, new Vector3(0, 4, 0), Quaternion.identity);

                questionText.text = "Question " + currentQuestion + ": Which piece of safety equipment did we not use?";
                Button1.GetComponentInChildren<TMP_Text>().text = "1";
                Button2.GetComponentInChildren<TMP_Text>().text = "2";
                Button3.GetComponentInChildren<TMP_Text>().text = "3";
                Button4.GetComponentInChildren<TMP_Text>().text = "4";
            }
        }
    }
    IEnumerator FadeOut()
    {
        // Calculate the target colour (fully transparent)
        Color targetColor = new Color(originalColour.r, originalColour.g, originalColour.b, 0.0f);

        // Lerp the colour from the original colour to the target color over the fade time
        float t = 0.0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float blend = Mathf.Clamp01(t / fadeTime);
            feedbackText.color = Color.Lerp(originalColour, targetColor, blend);
            yield return null;
        }

        // Wait for a brief moment before starting the fade in animation
        yield return new WaitForSeconds(1.0f);

        // Update
    }
}

