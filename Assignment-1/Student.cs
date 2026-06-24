// Holds all the data for one student.
public class Student
{
    public string FullName;
    public string StudentId;
    public string Programme;
    public string Level;

    // Scores for the 5 courses, in this fixed order:
    // 0 = Programming with C#, 1 = Database Systems,
    // 2 = Computer Networks, 3 = Web Development, 4 = Mathematics for Computing
    public double[] Scores = new double[5];

    public double Total;
    public double Average;
    public string Grade;
    public string Status;

    // Works out total, average, grade and pass/fail status from the scores.
    public void CalculateResults()
    {
        Total = 0;
        for (int i = 0; i < Scores.Length; i++)
        {
            Total += Scores[i];
        }

        Average = Total / Scores.Length;

        if (Average >= 80)
            Grade = "A";
        else if (Average >= 70)
            Grade = "B";
        else if (Average >= 60)
            Grade = "C";
        else if (Average >= 50)
            Grade = "D";
        else
            Grade = "F";

        Status = Average >= 50 ? "Passed" : "Failed";
    }
}
