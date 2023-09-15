using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace exercise_planner.Models.DbModels
{
    public class ExDetails
    {

        [Key]
        [ForeignKey("Exercise")]
        public int ExDetailsId { get; set; }

        public string Description { get; set; }
        public ExDetails() { }

        public ExDetails(int exDetailsId, string description)
        {
            ExDetailsId = exDetailsId;
            Description = description;
        }

        public virtual Exercise Exercise { get; set; }
    }
}