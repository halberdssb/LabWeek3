using Unity.VisualScripting;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    // Calculates challenge score for a course based on different field scores



    public string courseName; // name of the course

    // max for each int value is 100 - otherwise will return 10 if above
    [Range(0f, 100f)]
    public int numModules; // number of modules in the course
    [Range(0f, 100f)]
    public int numReadingMaterials; // number of reading materials for the course
    [Range(0f, 100f)]
    public int numQuizzes; // number of quizzes in the course
    [Range(0f, 100f)]
    public int numAssignments; // number of assignments in the course
    public bool hasInstructorTaughtBefore; // has the instructor taught the course or not?

    // score weight for each field
    private float numModulesWeight = 0.15f;
    private float numReadingMaterialsWeight = .3f;
    private float numQuizzesWeight = 0.15f;
    private float numAssignmentsWeight = 0.3f;
    private float hasInstructorTaughtBeforeWeight = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("The course " + courseName + " has a challenge score of " + CalculateTotalScore() + ".");
    }

    // calculates the weighted score for a single field
    private float CalculateFieldScore(int field, float weight)
    {
        // calculate percentage of the field and return
        return field * weight;
    }

    // overload for bool fields (like has instructor taught before)
    private float CalculateFieldScore(bool field, float weight)
    {
        // return full weight value if bool is true
        if (field)
        {
            return weight;
        }
        // otherwise, weight is 0
        else
        {
            return 0;
        }
    }

    private float CalculateTotalScore()
    {
        // create total score variable
        float totalScore = 0;

        // calculate individual field scores for each field based on their individual weights and add to total

        // num modules
        totalScore += CalculateFieldScore(numModules, numModulesWeight);

        // num reading materials
        totalScore += CalculateFieldScore(numReadingMaterials, numReadingMaterialsWeight);

        // num quizzes
        totalScore += CalculateFieldScore(numQuizzes, numQuizzesWeight);

        // num assignments
        totalScore += CalculateFieldScore(numAssignments, numAssignmentsWeight);

        // has been taught before
        totalScore += CalculateFieldScore(hasInstructorTaughtBefore, hasInstructorTaughtBeforeWeight);

        // return total score as value from 1 to 10 as int
        return (int)Mathf.Clamp(totalScore / 10, 1, 10);
    }
}
