using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace exercise_planner.Models.DbModels
{
    public enum Sex {Male, Female }
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string Name { get; set; }    
        public string Surname { get; set; }
        public Sex Sex1 { get; set; }
        public User() { }

        public User(int userid, float height, float weight, string name, string surname, Sex sex1)
        {
            UserId = userid;
            Height = height;
            Weight = weight;
            Name = name;
            Surname = surname;
            Sex1 = sex1;
        }
        public virtual ICollection<Plan> Plans { get; set; }
    }
}