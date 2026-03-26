using System;
using System.Collections.Generic;

namespace library_ver2.Models;

public partial class BookLoan
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdBook { get; set; }

    public DateOnly DateOfIssue { get; set; }

    public DateOnly PlannedReturnDate { get; set; }

    public DateOnly? ActualReturnDate { get; set; }

    public int IdStatus { get; set; }

    public virtual Book IdBookNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
