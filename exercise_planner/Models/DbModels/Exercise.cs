using exercise_planner.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace exercise_planner.Models.DbModels
{
    public enum Category { Shoulders, Biceps, Chest, Legs }
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set; }

        public Exercise() { }

        public Exercise(int exerciseId, Category category, string name, int series, int repetitions)
        {
            ExerciseId = exerciseId;
            Category = category;
            Name = name;
            Series = series;
            Repetitions = repetitions;
        }

        public List<Plan_Ex> Plan_Exes { get; set; }
        public virtual ExDetails ExDetails { get; set; }

    }
}