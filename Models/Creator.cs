using System;
using System.Collections.Generic;

namespace CW2_TrailService.Models;

public partial class Creator
{
    public int CreatorId { get; set; }

    public int? TrailId { get; set; }

    public string? Email { get; set; }

    public virtual Account? EmailNavigation { get; set; }

    public virtual Trail? Trail { get; set; }
}
