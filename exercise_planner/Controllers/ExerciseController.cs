using exercise_planner.Models.DbModels;
using exercise_planner.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exercise_planner.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly DatabaseContext _db;

        public ExerciseController()
        {
            _db = new DatabaseContext();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new Exercise());
        }

        [HttpPost]
        public ActionResult Create(Exercise exercise)
        {
            if (ModelState.IsValid)
            {

                var exDetails = new ExDetails
                {
                    Exercise = exercise,
                    Description = exercise.ExDetails.Description
                };

                exercise.ExDetails = exDetails;

                _db.Exercise.Add(exercise);
                _db.SaveChanges();

                return RedirectToAction("ViewAll");
            }

            return View(exercise);
        }

        [HttpGet]
        public ActionResult ViewAll()
        {
            List<Exercise> list = _db.Exercise.ToList();

            return View(list);
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            Exercise obj = _db.Exercise.FirstOrDefault(o => o.ExerciseId == id);

            return View(obj);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Exercise obj = _db.Exercise.FirstOrDefault(o => o.ExerciseId == id);

            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                var existingExercise = _db.Exercise.Include(e => e.ExDetails).FirstOrDefault(e => e.ExerciseId == exercise.ExerciseId);

                existingExercise.Category = exercise.Category;
                existingExercise.Name = exercise.Name;
                existingExercise.Series = exercise.Series;
                existingExercise.Repetitions = exercise.Repetitions;
                existingExercise.ExDetails.Description = exercise.ExDetails.Description;

                _db.Entry(existingExercise).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("ViewAll");
            }

            return View(exercise);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Exercise obj = _db.Exercise.FirstOrDefault(o => o.ExerciseId == id);

            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Exercise obj = _db.Exercise.FirstOrDefault(o => o.ExerciseId == id);
            ExDetails exDetails = _db.ExDetails.FirstOrDefault(o => o.Exercise.ExerciseId == id);

            _db.Exercise.Remove(obj);
            _db.ExDetails.Remove(exDetails);
            _db.SaveChanges();

            return RedirectToAction("ViewAll");
        }
    }
}
