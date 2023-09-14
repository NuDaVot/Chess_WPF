using System;
using System.Collections.Generic;

namespace Chess2.Data;

public partial class Report
{
    public int Idreport { get; set; }

    /// <summary>
    /// заявитель
    /// </summary>
    public int Subject { get; set; }

    /// <summary>
    /// ответчик 
    /// </summary>
    public int Object { get; set; }

    public int? IdGame { get; set; }

    public int? IdAdmin { get; set; }

    public string? Text { get; set; }

    /// <summary>
    /// 0 - на расмотрении\n1 - удовлетворена\n2 - отклонена 
    /// </summary>
    public int Status { get; set; }

    public virtual User? IdAdminNavigation { get; set; }

    public virtual Party? IdGameNavigation { get; set; }

    public virtual User ObjectNavigation { get; set; } = null!;

    public virtual User SubjectNavigation { get; set; } = null!;
}
