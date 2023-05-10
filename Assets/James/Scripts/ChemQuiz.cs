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

    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;

    private int currentQuestion = 1;

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;

    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;
    public GameObject prefab8;

    void Start()
    {
        // Get the TextMeshProUGUI component of the game object and store its original color
        originalColour = feedbackText.color;
    }

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
                prefab5 = Instantiate(prefab5, new Vector3(-3, 2, 5), Quaternion.identity);
                prefab6 = Instantiate(prefab6, new Vector3(-1, 1, 5), Quaternion.identity);
                prefab7 = Instantiate(prefab7, new Vector3(1, 3, 5), Quaternion.identity);
                prefab8 = Instantiate(prefab8, new Vector3(3, 4, 5), Quaternion.identity);

                StartCoroutine(FadeOut());

                questionText.text = "Question " + currentQuestion + ": 1?";
                Button1.GetComponentInChildren<TMP_Text>().text = "1";
                Button2.GetComponentInChildren<TMP_Text>().text = "2";
                Button3.GetComponentInChildren<TMP_Text>().text = "3";
                Button4.GetComponentInChildren<TMP_Text>().text = "4";
            }
            else
            {
                //Instantiate(prefab1, new Vector3(0, 2, 0), Quaternion.identity);
                //Instantiate(prefab2, new Vector3(0, 1, 0), Quaternion.identity);
                //Instantiate(prefab3, new Vector3(0, 3, 0), Quaternion.identity);
                //Instantiate(prefab4, new Vector3(0, 4, 0), Quaternion.identity);

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

