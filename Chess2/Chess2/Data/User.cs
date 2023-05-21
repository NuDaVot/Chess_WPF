using System;
using System.Collections.Generic;

namespace Chess2;

public partial class User
{
    public int Iduser { get; set; }

    public string? Nick { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? Rating { get; set; }

    /// <summary>
    /// 1 - играет 
    /// 0 - забанен
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// 1 - игрок \n0 - админ 
    /// </summary>
    public bool Role { get; set; }

    public virtual ICollection<Party> PartyBlackUserNavigations { get; } = new List<Party>();

    public virtual ICollection<Party> PartyWhiteUserNavigations { get; } = new List<Party>();
}
