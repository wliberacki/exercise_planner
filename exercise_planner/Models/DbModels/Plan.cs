using exercise_planner.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;

namespace exercise_planner.Models.DbModels
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }
        public List<Exercise> PlannedList { get; set; } = new List<Exercise>();
        public Plan() { }

        public Plan(int planId, List<Exercise> plannedList)
        {
            PlanId = planId;
            PlannedList = plannedList;
        }

        public List<Plan_Ex> Plan_Exes { get; set; }
        
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual User Users { get; set; }


    }
}   