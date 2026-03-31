using System;
using System.Collections.Generic;

namespace library_ver2.Models;

public partial class Order
{
    public int Id { get; set; }
    public int IdReader { get; set; }
    public int IdBook { get; set; }
    public DateTime DateOut { get; set; }
    public DateTime? ReturnDate { get; set; }

    public virtual User IdReaderNavigation { get; set; } = null!;
    public virtual Book IdBookNavigation { get; set; } = null!;
}

