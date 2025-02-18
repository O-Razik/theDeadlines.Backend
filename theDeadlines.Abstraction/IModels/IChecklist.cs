using System;
using System.Collections.Generic;

namespace theDeadlines.Abstraction.IModels
{
    public interface IChecklist
    {
        Guid Id { get; set; }

        string Name { get; set; }

        Guid SubDeadlineId { get; set; }

        ICollection<IChecklistItem> ChecklistItems { get; set; }

        ISubDeadline SubDeadline { get; set; }
    }
}