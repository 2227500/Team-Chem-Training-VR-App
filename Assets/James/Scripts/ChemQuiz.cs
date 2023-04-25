using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChemQuiz : MonoBehaviour
{
    public TMP_Text questionText;

    public TMP_Text feedbackText;


    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;


    private int currentQuestion = 1;

    public void CheckAnswer(int answer)
    {
        if (currentQuestion == 1 && answer == 3)
        {
            feedbackText.text = "Correct!";
        }
        else if (currentQuestion == 2 && answer == 1)
        {
            feedbackText.text = "Correct!";
        }
        else if (currentQuestion == 3 && answer == 3)
        {
            feedbackText.text = "Correct!";
        }
        else if (currentQuestion == 4 && answer == 1)
        {
            feedbackText.text = "Correct!";
        }
        else if (currentQuestion == 5 && answer == 3)
        {
            feedbackText.text = "Correct!";
        }
        else
        {
            feedbackText.text = "Incorrect!";
        }

        currentQuestion++;

        // Hide the quiz panel after the final question
        if (currentQuestion > 5)
        {
            gameObject.SetActive(false);
        }
        else
        {
            // Update the question text and answer options for the next question
            if (currentQuestion == 2)
            {
                questionText.text = "Question " + currentQuestion + ": Which of these components is the condenser?";
                Button1.GetComponentInChildren<TMP_Text>().text = "";
                Button2.GetComponentInChildren<TMP_Text>().text = "";
                Button3.GetComponentInChildren<TMP_Text>().text = "";
                Button4.GetComponentInChildren<TMP_Text>().text = "";
            }
            else if (currentQuestion == 3)
            {
                questionText.text = "Question " + currentQuestion + ": At the start of the experiment which valve do you not close?";
                Button1.GetComponentInChildren<TMP_Text>().text = "V12";
                Button2.GetComponentInChildren<TMP_Text>().text = "V5";
                Button3.GetComponentInChildren<TMP_Text>().text = "V4";
                Button4.GetComponentInChildren<TMP_Text>().text = "V8";
            }
            else if (currentQuestion == 4)
            {
                questionText.text = "Question " + currentQuestion + ": When you started P1 what did you set the feed flowrate to?";
                Button1.GetComponentInChildren<TMP_Text>().text = "60%";
                Button2.GetComponentInChildren<TMP_Text>().text = "75%";
                Button3.GetComponentInChildren<TMP_Text>().text = "50%";
                Button4.GetComponentInChildren<TMP_Text>().text = "40%";
            }
            else if (currentQuestion == 5)
            {
                questionText.text = "Question " + currentQuestion + ": ?";
                Button1.GetComponentInChildren<TMP_Text>().text = "";
                Button2.GetComponentInChildren<TMP_Text>().text = "";
                Button3.GetComponentInChildren<TMP_Text>().text = "";
                Button4.GetComponentInChildren<TMP_Text>().text = "";
            }
            else
            {
                questionText.text = "Question " + currentQuestion + ": Which piece of safety equipment did we not use?";
                Button1.GetComponentInChildren<TMP_Text>().text = "";
                Button2.GetComponentInChildren<TMP_Text>().text = "";
                Button3.GetComponentInChildren<TMP_Text>().text = "";
                Button4.GetComponentInChildren<TMP_Text>().text = "";
            }
        }
    }
}