namespace API.Helpers;

public class Authorization
{
    public enum Roles
    {
        
        Admin,
        Employee
    }

    public const Roles rol_default = Roles.Employee;
}