using System;
using System.Collections.Generic;

namespace CW2_TrailService.Models;

public partial class Site
{
    public int SiteId { get; set; }

    public int TrailId { get; set; }

    public int PlaceId { get; set; }

    public virtual Place Place { get; set; } = null!;

    public virtual Trail Trail { get; set; } = null!;
}
