namespace Assignment_2;

public class EmployeeReportService
{
    private String report = "";

    public void addData(String data) {
        report += data;
    }

    public void clearReport() {
        report = "";
    }

    public void outputReport() { 
        Console.WriteLine(report);
    }
}