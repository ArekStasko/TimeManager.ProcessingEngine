﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeManager.ProcessingEngine.Data
{

    public interface ITaskRecords
    {
        [Key]
        int Id { get; set; }
        Guid TaskId { get; set; }
        Guid UserId { get; set; }
        DateTime StartDate { get; set; }
        DateTime? EndDate { get; set; }
        DateTime? Deadline { get; set; }
        int Priority { get; set; }
        double? Efficiency { get; set; }
        bool Completed { get; set; }
        
        public TimeSpan Delay();

        public TimeSpan ExecutionTime();

        public double CalculateEfficiency();
    }
}
