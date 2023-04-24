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
        else if (currentQuestion == 3 && answer == 4)
        {
            feedbackText.text = "Correct!";
        }
        else if (currentQuestion == 4 && answer == 2)
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
                questionText.text = "Question " + currentQuestion + ": What is the capital of France?";
                Button1.GetComponentInChildren<TMP_Text>().text = "Paris";
                Button2.GetComponentInChildren<TMP_Text>().text = "London";
                Button3.GetComponentInChildren<TMP_Text>().text = "Berlin";
                Button4.GetComponentInChildren<TMP_Text>().text = "Madrid";
            }
            else if (currentQuestion == 3)
            {
                questionText.text = "Question " + currentQuestion + ": Who wrote The Great Gatsby?";
                Button1.GetComponentInChildren<TMP_Text>().text = "Ernest Hemingway";
                Button2.GetComponentInChildren<TMP_Text>().text = "F. Scott Fitzgerald";
                Button3.GetComponentInChildren<TMP_Text>().text = "William Faulkner";
                Button4.GetComponentInChildren<TMP_Text>().text = "John Steinbeck";
            }
            else if (currentQuestion == 4)
            {
                questionText.text = "Question " + currentQuestion + ": Which planet is closest to the sun?";
                Button1.GetComponentInChildren<TMP_Text>().text = "Venus";
                Button2.GetComponentInChildren<TMP_Text>().text = "Mars";
                Button3.GetComponentInChildren<TMP_Text>().text = "Mercury";
                Button4.GetComponentInChildren<TMP_Text>().text = "Jupiter";
            }
            else if (currentQuestion == 5)
            {
                questionText.text = "Question " + currentQuestion + ": Who painted the Mona Lisa?";
                Button1.GetComponentInChildren<TMP_Text>().text = "Vincent van Gogh";
                Button2.GetComponentInChildren<TMP_Text>().text = "Pablo Picasso";
                Button3.GetComponentInChildren<TMP_Text>().text = "Leonardo da Vinci";
                Button4.GetComponentInChildren<TMP_Text>().text = "Claude Monet";
            }
            else
            {
                questionText.text = "Question " + currentQuestion + ": What is the largest mammal on Earth?";
                Button1.GetComponentInChildren<TMP_Text>().text = "Elephant";
                Button2.GetComponentInChildren<TMP_Text>().text = "Whale";
                Button3.GetComponentInChildren<TMP_Text>().text = "Giraffe";
                Button4.GetComponentInChildren<TMP_Text>().text = "Hippopotamus";
            }
        }
    }
}