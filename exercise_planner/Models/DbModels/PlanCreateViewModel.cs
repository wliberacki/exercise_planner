using exercise_planner.Models.DbModels;
using exercise_planner.Models.DbModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace exercise_planner.Models
{
    public class PlanCreateViewModel
    {
        [Display(Name = "User")]
        [Required]
        public int SelectedUserId { get; set; }

        public List<User> Users { get; set; }

        [Display(Name = "Exercises")]
        [Required]
        public List<int> SelectedExercises { get; set; }

        public List<Exercise> Exercises { get; set; }
    }
}
