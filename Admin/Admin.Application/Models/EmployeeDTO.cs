using Admin.Domain.Entities;

namespace Admin.Application.Models;

public class EmployeeDTO
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Position { get; set; }

    public DateTime HireDate { get; set; }

    public DateTime BirthDate { get; set; }

    public decimal Salary { get; set; }

    public ICollection<CustomerDTO> Customers { get; set; }

    public ICollection<OrderDTO> Orders { get; set; }
}
