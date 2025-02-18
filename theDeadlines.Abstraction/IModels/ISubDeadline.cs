﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace theDeadlines.Abstraction.IModels;

public interface ISubDeadline
{
    Guid Id { get; set; }
    
    string Description { get; set; }
    
    Guid DeadlineId { get; set; }
    
    DateTime? DeadlineDate { get; set; }
    
    ICollection<IChecklist> Checklists { get; set; }
    
    IDeadline Deadline { get; set; }
}