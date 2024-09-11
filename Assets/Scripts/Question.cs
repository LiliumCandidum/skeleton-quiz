public class Question
{
    private string[] bones;
    private string[] answers;
    private string correctAnswer;

    private string question;

    public Question(string[] bones, string[] answers, string correctAnswer, string question)
    {
        this.bones = bones;
        this.answers = answers;
        this.correctAnswer = correctAnswer;
        this.question = question;
    }

    public string[] getBones() 
    {
        return this.bones;
    }

    public string[] getAnswers()
    {
        return this.answers;
    }

    public string getCorrectAnswer()
    {
        return this.correctAnswer;
    }

    public string getQuestion()
    {
        return this.question;
    }
}
