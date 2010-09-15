using System.Net;
using System.Web.Mvc;
using EasyCRM.Model.Domains;
using EasyCRM.Model.Services;
using EasyCRM.Model.Services.Impl;

namespace EasyCRM.WebApp.Controllers
{
    [Authorize]
    public class SectorController : Controller
    {
        private IIndustrialSectorService _sectorService;

        public SectorController()
        {
            _sectorService = new IndustrialSectorService(new ModelStateWrapper(this.ModelState));
        }

        public SectorController(IIndustrialSectorService service)
        {
            _sectorService = service;
        }

        //
        // GET: /Sector/

        public ActionResult Index()
        {
            //we list all sectors from db, and pass them to the view
            return View(_sectorService.ListIndustrialSectors());
        }

        //
        // GET: /Sector/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sector/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")] IndustrialSector industrialSector)
        {
            if (!_sectorService.CreateIndustrialSector(industrialSector))
            {
                return View(industrialSector);
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Sector/Edit/5

        public ActionResult Edit(int id)
        {
            var sector = _sectorService.GetIndustrialSector(id);

            if (sector == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            return View(sector);
        }

        //
        // POST: /Sector/Edit/5

        [HttpPost]
        public ActionResult Edit(IndustrialSector industrialSector)
        {
            // normaly we should have those parameters : "Edit(int id, FormCollection values)"
            // Then we would retrieve the existing sector from db (by his id) and then update the 
            // fields with the form posted values.But in this specific case we can directly
            // pass an "IndustrialSector" instance, the binder has automatically bound the "id" 
            // field from the request(/Sector/Edit/{id}) and the "sector" field from the form.
            // ...

            if (!_sectorService.EditIndustrialSector(industrialSector))
            {
                return View(industrialSector);
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Sector/Delete/5

        public ActionResult Delete(int id)
        {
            var sector = _sectorService.GetIndustrialSector(id);

            if (sector == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            return View(sector);
        }

        //
        // POST: /Sector/Delete/5

        [HttpPost]
        public ActionResult Delete(IndustrialSector industrialSector)
        {
            if (!_sectorService.DeleteIndustrialSector(industrialSector))
                return View(industrialSector);
            return RedirectToAction("Index");

        }
    }
}
