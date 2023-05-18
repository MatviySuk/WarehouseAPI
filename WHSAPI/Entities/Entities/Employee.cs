using System;
using System.Collections.Generic;

namespace WHSAPI.Entities.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime? HireDate { get; set; }

    public string JobTitle { get; set; } = null!;

    public decimal Salary { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; } = new List<EmployeeRole>();
}
