using System;
using System.Collections.Generic;

namespace theDeadlines.Abstraction.IModels;

public interface IChecklistItem
{
    Guid Id { get; set; }

    string Name { get; set; }
    
    bool IsCompleted { get; set; }
    
    Guid ChecklistId { get; set; }
    
    IChecklist Checklist { get; set; }
}