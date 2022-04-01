namespace Assignment_2;

public class Employee
{
    private const String RequiredMsg = " is mandatory ";
    private const String Newline = "\n";

    private String _firstName { get; set; }
    private String _lastName { get; set; }
    private String _ssn { get; set; }
    private bool _metWithHr;
    private bool _metDeptStaff;
    private bool _reviewedDeptPolicies;
    private bool _movedIn;
    private String _cubeId { get; set; }
    private DateTime _orientationDate = DateTime.Now;
    private EmployeeReportService reportService = new EmployeeReportService();

    /*
        Notice we force certain mandatory properties by using a custom
        constructor. But we use the setter method to perform validation.
     */
    public Employee(String firstName, String lastName, String ssn) {
        // Using setter method guarantees validation will be performed
        // Ignore the warning messages for now. Will be explained later
        validateFirstName(firstName);
        validateLastName(lastName);
        validateSsn(ssn);
    }

    /*
        This should be private because it is useful only to this class and then,
        only as a helper method to other methods. This is method hiding - a type
        of encapsulation where we put frequently used code in one place for easy
        reuse and editing.
     */
    private String createCurrentDate()
    {
        DateTime formatter = _orientationDate;
        var formattedDate = formatter.ToString();
        return formattedDate;
    }

    /*
        This method is public because it must be available to other classes in
        this project. Notice that it controls the order in which the helper methods
        are called. Order isn't always an issue, but here it obviously is, which
        may be an important requirement.
     */
    public void doFirstTimeOrientation(String cubeId) {
        _orientationDate = DateTime.Now;
        meetWithHrForBenefitAndSalaryInfo();
        meetDepartmentStaff();
        reviewDeptPolicies();
        moveIntoCubicle(cubeId);
    }
    
    private void meetWithHrForBenefitAndSalaryInfo() {
        _metWithHr = true;
        reportService.addData(_firstName + " " + _lastName + " met with HR on "
                + createCurrentDate() + Newline);
    }
    
    private void meetDepartmentStaff() {
        _metDeptStaff = true;
        reportService.addData(_firstName + " " + _lastName + " met with dept staff on "
                + createCurrentDate() + Newline);
    }
    
    private void reviewDeptPolicies() {
        _reviewedDeptPolicies = true;
        reportService.addData(_firstName + " " + _lastName + " reviewed dept policies on "
                + createCurrentDate() + Newline);
    }
    
    private void moveIntoCubicle(String cubeId) {
        _cubeId = cubeId;
        _movedIn = true;
        reportService.addData(_firstName + " " + _lastName + " moved into cubicle "
                + cubeId + " on " + createCurrentDate() + Newline);
    }
    
    public void validateFirstName(String firstName) {
        if (string.IsNullOrEmpty(firstName)) {
            throw new ArgumentException("first name" + RequiredMsg);
        }
        _firstName = firstName;
    }

    public void validateLastName(String lastName) {
        if (string.IsNullOrEmpty(lastName)) {
            throw new ArgumentException("last name" + RequiredMsg);
        }
        this._lastName = lastName;
    }

    public void validateSsn(String ssn) {
        if (ssn == null || ssn.Length < 9 || ssn.Length > 11) {
            throw new ArgumentException("ssn" + RequiredMsg
                    + "and must be between 9 and 11 characters (if hyphens are used)");
        }
        _ssn = ssn;
    }

    public void validateCubeId(String cubeId) {
        if (string.IsNullOrEmpty(cubeId)) {
            throw new ArgumentException("cube id" + RequiredMsg);
        }
        _cubeId = cubeId;
    }

    public void printReport() {
        reportService.outputReport();
    }
}