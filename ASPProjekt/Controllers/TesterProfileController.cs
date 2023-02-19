using ASPProjekt.Data;
using ASPProjekt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjekt.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TesterProfileController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public TesterProfileController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {   
            IEnumerable<TesterProfile> objProfilesList = dbContext.TesterProfiles.ToList();
            return View(objProfilesList);
        }

        //GET
        public IActionResult Create()
        {

            return View();

        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TesterProfile profile)
        {   if(profile.Name == profile.Surname.ToString())
            {
                ModelState.AddModelError("name", "The Name cannot exactly match the Surname");
            }
            try
            {
                dbContext.TesterProfiles.Add(profile);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var testerfromDb = dbContext.TesterProfiles.Find(id);
            //var testerfromDbFirst = dbContext.TesterProfiles.FirstOrDefault(p=>p.Id == id);
            //var testerfromDbSingle = dbContext.TesterProfiles.SingleOrDefault(p => p.Id == id);

            if(testerfromDb == null)
            {
                return NotFound();
            }
            return View(testerfromDb);

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TesterProfile profile)
        {
            try {
                dbContext.TesterProfiles.Update(profile);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var testerfromDb = dbContext.TesterProfiles.Find(id);
            //var testerfromDbFirst = dbContext.TesterProfiles.FirstOrDefault(p=>p.Id == id);
            //var testerfromDbSingle = dbContext.TesterProfiles.SingleOrDefault(p => p.Id == id);

            if (testerfromDb == null)
            {
                return NotFound();
            }
            return View(testerfromDb);

        }



        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id) 
        { 
            var profile = dbContext.TesterProfiles.Find(id);
            if(profile == null)
            { return NotFound(); }

            dbContext.TesterProfiles.Remove(profile);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
