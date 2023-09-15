using exercise_planner.Models.DbModels;
using exercise_planner.Models;
using exercise_planner.Models.DbModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace exercise_planner.Controllers
{
    public class PlanController : Controller
    {
        private readonly DatabaseContext _db;

        public PlanController()
        {
            _db = new DatabaseContext();
        }

        public ActionResult Create()
        {
            // Pobranie wszystkich użytkowników z bazy danych
            List<User> users = _db.User.ToList();

            // Pobranie wszystkich ćwiczeń z bazy danych
            List<Exercise> exercises = _db.Exercise.ToList();

            var viewModel = new PlanCreateViewModel
            {
                Users = users,
                Exercises = exercises
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(PlanCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Tworzenie nowego planu treningowego
                Plan plan = new Plan
                {
                    UserId = viewModel.SelectedUserId,
                    PlannedList = _db.Exercise.Where(e => viewModel.SelectedExercises.Contains(e.ExerciseId)).ToList()
                };

                // Zapisanie planu treningowego do bazy danych
                _db.Plan.Add(plan);
                _db.SaveChanges();

                return RedirectToAction("ViewAll");
            }

            // Jeśli model nie jest poprawny, pobierz listy użytkowników i ćwiczeń ponownie
            viewModel.Users = _db.User.ToList();
            viewModel.Exercises = _db.Exercise.ToList();

            return View(viewModel);
        }

        public ActionResult ViewAll()
        {
            // Pobranie wszystkich planów treningowych z bazy danych
            List<Plan> plans = _db.Plan.ToList();

            return View(plans);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            // Pobierz plan o podanym id z bazy danych
            var plan = _db.Plan.Include(p => p.Plan_Exes).SingleOrDefault(p => p.PlanId == id);

            if (plan == null)
            {
                return HttpNotFound();
            }

            var viewModel = new PlanEditViewModel
            {
                PlanId = plan.PlanId,
                SelectedUserId = plan.UserId,
                Users = _db.User.ToList(),
                SelectedExercises = plan.Plan_Exes != null ? plan.Plan_Exes.Select(e => e.ExerciseId).ToList() : new List<int>(),
                Exercises = _db.Exercise.ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Edit(PlanEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Pobierz plan o podanym id z bazy danych
                var plan = _db.Plan.Include(p => p.Plan_Exes).SingleOrDefault(p => p.PlanId == viewModel.PlanId);

                if (plan == null)
                {
                    return HttpNotFound();
                }

                // Zaktualizuj dane planu na podstawie danych z formularza
                plan.UserId = viewModel.SelectedUserId;

                // Usuń stare powiązania z ćwiczeniami
                plan.Plan_Exes.Clear();

                // Dodaj nowe powiązania z ćwiczeniami na podstawie zaznaczonych wartości z formularza
                var selectedExercises = _db.Exercise.Where(e => viewModel.SelectedExercises.Contains(e.ExerciseId)).ToList();
                var planExes = selectedExercises.Select(exercise => new Plan_Ex { PlanId = plan.PlanId, ExerciseId = exercise.ExerciseId }).ToList();
                plan.Plan_Exes.AddRange(planExes);

                // Zapisz zmiany
                _db.SaveChanges();

                return RedirectToAction("ViewAll");
            }


            viewModel.Users = _db.User.ToList();
            viewModel.Exercises = _db.Exercise.ToList();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            // Pobierz plan o podanym id z bazy danych
            var plan = _db.Plan.Find(id);

            if (plan == null)
            {
                return HttpNotFound();
            }

            return View(plan);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            // Pobierz plan o podanym id z bazy danych
            var plan = _db.Plan.Find(id);

            if (plan == null)
            {
                return HttpNotFound();
            }

            // Usuń plan z bazy danych
            _db.Plan.Remove(plan);
            _db.SaveChanges();

            return RedirectToAction("ViewAll");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            // Pobierz plan o podanym id z bazy danych
            var plan = _db.Plan.Include(p => p.PlannedList).SingleOrDefault(p => p.PlanId == id);

            if (plan == null)
            {
                return HttpNotFound();
            }

            return View(plan);
        }

    }
}
