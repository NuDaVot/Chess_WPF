using System;
using System.Collections.Generic;

namespace Chess2.Data;

public partial class Party
{
    public int Idparty { get; set; }

    /// <summary>
    /// iD белого игрока 
    /// </summary>
    public int WhiteUser { get; set; }

    /// <summary>
    /// iD черного игрока 
    /// </summary>
    public int BlackUser { get; set; }

    /// <summary>
    /// 0 - класический\n1 - на время 
    /// </summary>
    public bool? Mode { get; set; }

    /// <summary>
    /// 0 - белый проиграл 
    /// 1 - белый выйграл 
    /// </summary>
    public int? Result { get; set; }

    public string? Notation { get; set; }

    public TimeOnly? Duration { get; set; }

    public DateTime? Date { get; set; }

    /// <summary>
    /// 1 - играет \\n0 - забанен
    /// </summary>
    public sbyte? Status { get; set; }

    public virtual User BlackUserNavigation { get; set; } = null!;

    public virtual ICollection<Report> Reports { get; } = new List<Report>();

    public virtual User WhiteUserNavigation { get; set; } = null!;
}
