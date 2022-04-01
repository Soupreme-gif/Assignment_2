namespace Assignment_2;

public class HrPerson
{
    private const int GOTHIRED = 75;
    private OutputService output = new OutputService();
    private bool wasHired = false;

    public bool Interview()
    {

        output.displayOutput("An employee is being interviewed");

        Random hiringNumber = new Random();

        int randomNumber = hiringNumber.Next(1, 101);

        if(randomNumber >= GOTHIRED)
        {

            output.displayOutput("YAY they've been hired");
            wasHired = true;
            return wasHired;

        }
        else {

            output.displayOutput("This employee was not hired");
            wasHired = false;
            return wasHired;

        }

    }

}

