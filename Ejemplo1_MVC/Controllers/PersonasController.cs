using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ejemplo1_MVC.Models;

namespace Ejemplo1_MVC.Controllers;

public class PersonasController : Controller
{
    // Static list to simulate a data source
    private static List<PersonaViewModel> personas = new List<PersonaViewModel>
    {
        new APersonaViewModel { Id = 1, Nombre = "Juan", Edad = 30 },
        new APersonaViewModel { Id = 2, Nombre = "Maria", Edad = 25 }
    };

    // GET: Personas
    public ActionResult Index()
    {
        return View(personas);
    }

    // GET: Personas/Details/5
    public ActionResult Details(int id)
    {
        var persona = personas.FirstOrDefault(p => p.Id == id);
        if (persona == null)
        {
            return HttpNotFound();
        }
        return View(persona);
    }

    // GET: Personas/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Personas/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(PersonaViewModel model)
    {
        if (ModelState.IsValid)
        {
            model.Id = personas.Count > 0 ? personas.Max(p => p.Id) + 1 : 1;
            personas.Add(model);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    // GET: Personas/Edit/5
    public ActionResult Edit(int id)
    {
        var persona = personas.FirstOrDefault(p => p.Id == id);
        if (persona == null)
        {
            return HttpNotFound();
        }
        return View(persona);
    }

    // POST: Personas/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(APersonaViewModel model)
    {
        if (ModelState.IsValid)
        {
            var persona = personas.FirstOrDefault(p => p.Id == model.Id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            persona.Nombre = model.Nombre;
            persona.Edad = model.Edad;
            return RedirectToAction("Index");
        }
        return View(model);
    }

    // GET: Personas/Delete/5
    public ActionResult Delete(int id)
    {
        var persona = personas.FirstOrDefault(p => p.Id == id);
        if (persona == null)
        {
            return HttpNotFound();
        }
        return View(persona);
    }

    // POST: Personas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var persona = personas.FirstOrDefault(p => p.Id == id);
        if (persona != null)
        {
            personas.Remove(persona);
        }
        return RedirectToAction("Index");
    }
}
