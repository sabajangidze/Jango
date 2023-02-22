namespace Admin.Application.Models;

public class CustomerDTO
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public ICollection<EmployeeDTO> Employees { get; set; }

    public ICollection<OrderDTO> Orders { get; set; }
}
