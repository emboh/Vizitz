using System;

namespace Vizitz.IEntities
{
    public interface IHasTimestamps
    {
        DateTime? Added { get; set; }

        DateTime? Modified { get; set; }

        DateTime? Deleted { get; set; }
    }
}
