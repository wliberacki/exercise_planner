using exercise_planner.Models.DbModels;
using exercise_planner.Models;
using exercise_planner.Models.DbModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

public class UserController : Controller
{
    private readonly DatabaseContext _db;

    public UserController()
    {
        _db = new DatabaseContext();
    }

    [HttpGet]
    public ActionResult Create()
    {
        var exercise = new Exercise();
        exercise.ExDetails = new ExDetails();
        return View(exercise);
    }

    [HttpPost]
    public ActionResult Create(Exercise exercise)
    {
        if (ModelState.IsValid)
        {

            _db.Exercise.Add(exercise);
            _db.SaveChanges();

            return RedirectToAction("ViewAll");
        }


        return View(exercise);
    }

    public ActionResult ViewAll()
    {
        List<User> users = _db.User.ToList();

        return View(users);
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        User user = _db.User.Find(id);
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        User user = _db.User.Find(id);
        if (user == null)
        {
            return HttpNotFound();
        }
        _db.User.Remove(user);
        _db.SaveChanges();
        return RedirectToAction("ViewAll");
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        User obj;
        using (DatabaseContext db = new DatabaseContext())
        {
            obj = db.User.FirstOrDefault(o => o.UserId == id);
        }
        return View(obj);
    }

    [HttpPost]
    public ActionResult Edit(User user)
    {
        if (ModelState.IsValid)
        {
            _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("ViewAll");
        }
        return View(user);
    }


}
