using System;
using System.Collections.Generic;

namespace Chess2.Data;

public partial class User
{
    public int Iduser { get; set; }

    public string Nick { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? Rating { get; set; } = 0;

    /// <summary>
    /// 1 - играет \n0 - забанен
    /// </summary>
    public bool? Status { get; set; } = true;

    /// <summary>
    /// 1 - игрок \n0 - админ 
    /// </summary>
    public bool Role { get; set; } = true;

    public virtual ICollection<Party> PartyBlackUserNavigations { get; } = new List<Party>();

    public virtual ICollection<Party> PartyWhiteUserNavigations { get; } = new List<Party>();

    public virtual ICollection<Report> ReportIdAdminNavigations { get; } = new List<Report>();

    public virtual ICollection<Report> ReportObjectNavigations { get; } = new List<Report>();

    public virtual ICollection<Report> ReportSubjectNavigations { get; } = new List<Report>();
}
