using System;
using System.Collections.Generic;

namespace theDeadlines.Abstraction.IModels;

public interface IDeadline
{
    Guid Id { get; set; }
    
    string Name { get; set; }
    
    ICollection<ISubDeadline> SubDeadlines { get; set; }
}