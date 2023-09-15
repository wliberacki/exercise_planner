using exercise_planner.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace exercise_planner.Models.DbModels
{
    public class Plan_Ex
    {
        [Key]
        [Column(Order = 0)]
        public int PlanId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ExerciseId { get; set; }

        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }

        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }
    }
}